using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace CLVShare
{
    public class SNSConfig
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }

        public static SNSConfig load()
        {
            var confPath = makeConfigFilePath();

            var ins = new StreamReader(confPath, Encoding.UTF8);
            var yaml = new YamlStream();
            yaml.Load(ins);

            var root = yaml.Documents[0].RootNode;
            YamlMappingNode rootMap = root as YamlMappingNode;

            foreach (var ch in rootMap.Children)
            {
                var k = ch.Key.ToString();
                if (ieq(k, "twitter"))
                {
                    var conf = new SNSConfig();
                    if (conf.readTwitterConf(ch.Value as YamlMappingNode))
                    {
                        return conf;
                    }
                }
            }

            return null;
        }

        public static bool createTemplateIf()
        {
            var confPath = makeConfigFilePath();
            if (!File.Exists(confPath))
            {
                var s = 
                    "Twitter:\n" +
                    "  ConsumerKey: xxxxxxxx\n" +
                    "  ConsumerSecret: xxxxxxxxxxxx\n" +
                    "  AccessToken: xxxxxxxx\n" +
                    "  AccessTokenSecret: xxxxxxxxxxxx\n";

                var w = new System.IO.StreamWriter(confPath);
                w.Write(s);
                w.Close();

                return true;
            }

            return false;
        }

        public static string makeConfigFilePath()
        {
            var execPath = Application.ExecutablePath;
            var dir = Path.GetDirectoryName(execPath);

            return $"{dir}\\accounts.yaml";
        }

        protected bool readTwitterConf(YamlMappingNode parentNode)
        {
            if (null == parentNode)
            {
                return false;
            }

            foreach (var ch in parentNode.Children)
            {
                var k = ch.Key.ToString();
                if (ieq(k, "consumerkey"))
                {
                    ConsumerKey = ch.Value.ToString();
                }
                else if (ieq(k, "consumersecret"))
                {
                    ConsumerSecret = ch.Value.ToString();
                }
                else if (ieq(k, "accesstoken"))
                {
                    AccessToken = ch.Value.ToString();
                }
                else if (ieq(k, "accesstokensecret"))
                {
                    AccessTokenSecret = ch.Value.ToString();
                }
            }

            return validate();
        }

        public bool validate()
        {
            return valid_str(ConsumerKey) && valid_str(ConsumerSecret) && valid_str(AccessToken) && valid_str(AccessTokenSecret);
        }

        public bool isProductionToken()
        {
            return System.Text.RegularExpressions.Regex.IsMatch(AccessToken, "[^x]");
        }

        public static bool valid_str(string s)
        {
            return (null != s) && s.Length > 0;
        }

        public static bool ieq(string s1, string s2)
        {
            return s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
