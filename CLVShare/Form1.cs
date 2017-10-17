using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using com.clusterrr.clovershell;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLVShare
{
    public partial class Form1 : Form
    {
        public static bool TestNetworkError = false;

        public static ClovershellConnection clvshell;
        protected CoreTweet.Tokens twitterTokens;
        protected System.Media.SoundPlayer sndSuccess = new System.Media.SoundPlayer(Resource1.gbding);
        protected System.Media.SoundPlayer sndTweet = new System.Media.SoundPlayer(Resource1.gbtw);
        protected System.Media.SoundPlayer sndBad = new System.Media.SoundPlayer(Resource1.badsound);

        protected string lastImageName;
        protected SNSConfig configTwitter;

        public Form1()
        {
            InitializeComponent();
            lastImageName = "";
            clvshell = new ClovershellConnection() { AutoReconnect = true, Enabled = true };

            SNSConfig.createTemplateIf();
            configTwitter = SNSConfig.load();

            if (null != configTwitter)
            {
                if (configTwitter.isProductionToken())
                {
                    displayTwitterAccountValid(true);
                    twitterTokens = CoreTweet.Tokens.Create(configTwitter.ConsumerKey, configTwitter.ConsumerSecret, configTwitter.AccessToken,
                        TestNetworkError ? "0000" : configTwitter.AccessTokenSecret);
                }
                else
                {
                    labelTwhint.Text = "Generate tokens on Twitter web before using.";
                    labelTwhint.Visible = true;
                }
            }
            showState("Please connect your console before taking screenshot.", 0);
        }

        protected void displayTwitterAccountValid(bool enabled)
        {
            showAccountStateLabel(labelTwState, enabled);
        }

        public static void showAccountStateLabel(Label lab, bool enabled)
        {
            if (enabled)
            {
                lab.ForeColor = Color.DarkGreen;
                lab.Text = "✓ Ready";
            }
            else
            {
                lab.ForeColor = Color.Black;
                lab.Text = "Disabled";
            }
        }

        public void showState(string message, int errorLevel)
        {
            labelState.Text = message;
            labelState.ForeColor = (errorLevel > 0) ? Color.Red : Color.Black;
        }

        private void buttonShot_Click(object sender, EventArgs e)
        {
            // Check connection
            bool conn_success = false;
            for (int i = 0; i < 2; ++i)
            {
                if (clvshell.IsOnline)
                {
                    conn_success = true;
                    break;
                }
                System.Threading.Thread.Sleep(200);
            }

            if (conn_success)
            {
                Console.WriteLine("OK: CLV console is connected.");
                Bitmap screenshotImage = captureScreen();

                pbSSPreview.Image = screenshotImage;
                pbSSPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                buttonSaveSS.Enabled = true;
                buttonPost.Enabled = (null != twitterTokens);

                var nowTime = System.DateTime.Now;
                showState($"Screenshot taken at {nowTime}", 0);
                updateFilename(nowTime);
                sndSuccess.Play();
            }
            else
            {
                showState("[SCREENSHOT FAILED] Console is offline.", 1);
                sndBad.Play();
            }
        }

        protected void updateFilename(DateTime t)
        {
            lastImageName = t.ToString("CLV_yyyyMMdd_HHmmss");
        }

        public static int ConsoleScreenWidth = 1280;
        public static int ConsoleScreenHeight = 720;
        public Bitmap captureScreen()
        {
            // First, search canoe(official emulator) process
            Int64 emulatorPid = findEmulatorProcess(clvshell, "[c]anoe");
            if (emulatorPid < 0)
            {
                Debug.WriteLine("Canoe can't be found. Searching home menu...");
                // Second, search home menu process
                emulatorPid = findEmulatorProcess(clvshell, "[R]eedPlayer-Clover");
                if (emulatorPid < 0)
                {
                    Debug.WriteLine("Valid PIDs can't be found. Capturing without SIGSTOP.");
                }
            }

            var screenshotImage = new Bitmap(ConsoleScreenWidth, ConsoleScreenHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var rawStream = new MemoryStream();
            pauseEmulatorProcess(clvshell, emulatorPid);
            clvshell.Execute("cat /dev/fb0", null, rawStream, null, 1000, true);
            resumeEmulatorProcess(clvshell, emulatorPid);
            var raw = rawStream.ToArray();

            BitmapData data = screenshotImage.LockBits(
                new Rectangle(0, 0, screenshotImage.Width, screenshotImage.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            copyBitmapData(
                data, raw,
                screenshotImage.Width, screenshotImage.Height);
            screenshotImage.UnlockBits(data);

            return screenshotImage;
        }

        public static void copyBitmapData(BitmapData dest, byte[] raw, int width, int height)
        {
            int rawOffset = 0;

            unsafe
            {
                for (int y = 0; y < height; ++y)
                {
                    byte* row = (byte*)dest.Scan0 + (y * dest.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < width; ++x)
                    {
                        row[columnOffset] = raw[rawOffset];
                        row[columnOffset + 1] = raw[rawOffset + 1];
                        row[columnOffset + 2] = raw[rawOffset + 2];

                        columnOffset += 3;
                        rawOffset += 4;
                    }
                }
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sndTweet.Dispose();
            sndSuccess.Dispose();
            sndBad.Dispose();
            Process.GetCurrentProcess().Kill(); // Suicide! Just easy and dirty way to kill all threads.
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            bool with_tag = cbAddTag.Checked;
            var image = generatePngImage();

            if (null != twitterTokens && null != image)
            {
                string text = makeCommentText(with_tag) + (with_tag ? "#CLVShare" : "");

                try
                {
                    CoreTweet.MediaUploadResult res = twitterTokens.Media.Upload(image);
                    twitterTokens.Statuses.Update(status: text, media_ids: new long[] { res.MediaId });
                }
                catch (CoreTweet.TwitterException err)
                {
                    Debug.WriteLine(err);
                    showState($"Failed to upload.  Message from client: { err.Message }", 1);
                    sndBad.Play();

                    return;
                }


                showState($"Image uploaded at { System.DateTime.Now }", 0);
                sndTweet.Play();
                textBoxComment.Text = "";
            }
        }

        public string makeCommentText(bool with_tag)
        {
            var s = textBoxComment.Text;
            if (null != s && s.Length > 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(s, "[^\\s]"))
                {
                    if (with_tag)
                    {
                        return s + " ";
                    }
                    else
                    {
                        return s;
                    }
                }
            }

            return ""; // empty
        }

        public MemoryStream generatePngImage()
        {
            if (null != pbSSPreview.Image)
            {
                var ms = new MemoryStream();
                pbSSPreview.Image.Save(ms, ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                return ms;
            }

            return null;
        }

        // -- Emulator stop-and-go routines --
        // Stop emulator process to suppress tearing of the frame buffer.
        public static Int64 findEmulatorProcess(ClovershellConnection sh, string grepPattern)
        {
            var stdoutResult = new MemoryStream();
            sh.Execute($"ps|grep {grepPattern}", null, stdoutResult, null, 1000, false);
            var resultStr = Encoding.UTF8.GetString(stdoutResult.ToArray());
            resultStr = System.Text.RegularExpressions.Regex.Replace(resultStr, "^\\s+", ""); // Trim whitespaces

            var fields = System.Text.RegularExpressions.Regex.Split(resultStr, " +");
            if (fields.Length < 1)
            {
                return -1; // emulator not found
            }

            try
            {
                Int64 pid = Convert.ToInt64(fields[0], 10);
                Debug.WriteLine($"Found PID: {grepPattern} -> {pid}");
                return pid;
            }
            catch
            {
                Debug.WriteLine("Bad PID : " + resultStr);
                return -1;
            }
        }

        public static void pauseEmulatorProcess(ClovershellConnection sh, Int64 pid)
        {
            if (pid < 0) { return; } // emulator not found
            sh.Execute($"kill -s SIGSTOP {pid}", null, null, null, 1000, false);
        }

        public static void resumeEmulatorProcess(ClovershellConnection sh, Int64 pid)
        {
            if (pid < 0) { return; } // emulator not found
            sh.Execute($"kill -s SIGCONT {pid}", null, null, null, 1000, false);
        }


        private void buttonSaveSS_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.FileName = $"{lastImageName}.png";
            dlg.Filter = "PNG images(*.png)|*.png|All files(*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbSSPreview.Image.Save(dlg.FileName);
            }
        }

        private void labelTwhint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://apps.twitter.com/");
        }
    }
}
