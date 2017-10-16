namespace CLVShare
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonShot = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTW = new System.Windows.Forms.Label();
            this.pbSSPreview = new System.Windows.Forms.PictureBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.cbAddTag = new System.Windows.Forms.CheckBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.buttonSaveSS = new System.Windows.Forms.Button();
            this.labelTwState = new System.Windows.Forms.Label();
            this.groupBoxAccounts = new System.Windows.Forms.GroupBox();
            this.labelTwhint = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSSPreview)).BeginInit();
            this.groupBoxAccounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShot
            // 
            this.buttonShot.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonShot.Location = new System.Drawing.Point(17, 19);
            this.buttonShot.Name = "buttonShot";
            this.buttonShot.Size = new System.Drawing.Size(174, 55);
            this.buttonShot.TabIndex = 0;
            this.buttonShot.Text = "Take screenshot";
            this.buttonShot.UseVisualStyleBackColor = true;
            this.buttonShot.Click += new System.EventHandler(this.buttonShot_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.buttonShot);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 92);
            this.panel1.TabIndex = 1;
            // 
            // labelTW
            // 
            this.labelTW.AutoSize = true;
            this.labelTW.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTW.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelTW.Location = new System.Drawing.Point(238, 31);
            this.labelTW.Name = "labelTW";
            this.labelTW.Size = new System.Drawing.Size(55, 14);
            this.labelTW.TabIndex = 4;
            this.labelTW.Text = "Twitter";
            // 
            // pbSSPreview
            // 
            this.pbSSPreview.BackColor = System.Drawing.Color.Black;
            this.pbSSPreview.Location = new System.Drawing.Point(12, 133);
            this.pbSSPreview.Name = "pbSSPreview";
            this.pbSSPreview.Size = new System.Drawing.Size(640, 360);
            this.pbSSPreview.TabIndex = 7;
            this.pbSSPreview.TabStop = false;
            // 
            // buttonPost
            // 
            this.buttonPost.Enabled = false;
            this.buttonPost.Location = new System.Drawing.Point(577, 503);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 8;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // cbAddTag
            // 
            this.cbAddTag.AutoSize = true;
            this.cbAddTag.Checked = true;
            this.cbAddTag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAddTag.Location = new System.Drawing.Point(446, 507);
            this.cbAddTag.Name = "cbAddTag";
            this.cbAddTag.Size = new System.Drawing.Size(127, 16);
            this.cbAddTag.TabIndex = 9;
            this.cbAddTag.Text = "With #CLVShare tag";
            this.cbAddTag.UseVisualStyleBackColor = true;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(69, 505);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(365, 19);
            this.textBoxComment.TabIndex = 10;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(11, 509);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(53, 12);
            this.labelComment.TabIndex = 11;
            this.labelComment.Text = "Comment";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(12, 111);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(62, 12);
            this.labelState.TabIndex = 12;
            this.labelState.Text = "Launching...";
            // 
            // buttonSaveSS
            // 
            this.buttonSaveSS.Enabled = false;
            this.buttonSaveSS.Location = new System.Drawing.Point(545, 107);
            this.buttonSaveSS.Name = "buttonSaveSS";
            this.buttonSaveSS.Size = new System.Drawing.Size(107, 23);
            this.buttonSaveSS.TabIndex = 13;
            this.buttonSaveSS.Text = "Save to file...";
            this.buttonSaveSS.UseVisualStyleBackColor = true;
            this.buttonSaveSS.Click += new System.EventHandler(this.buttonSaveSS_Click);
            // 
            // labelTwState
            // 
            this.labelTwState.AutoSize = true;
            this.labelTwState.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTwState.Location = new System.Drawing.Point(299, 31);
            this.labelTwState.Name = "labelTwState";
            this.labelTwState.Size = new System.Drawing.Size(64, 14);
            this.labelTwState.TabIndex = 15;
            this.labelTwState.Text = "Disabled";
            // 
            // groupBoxAccounts
            // 
            this.groupBoxAccounts.Controls.Add(this.labelTwhint);
            this.groupBoxAccounts.Location = new System.Drawing.Point(228, 12);
            this.groupBoxAccounts.Name = "groupBoxAccounts";
            this.groupBoxAccounts.Size = new System.Drawing.Size(424, 92);
            this.groupBoxAccounts.TabIndex = 16;
            this.groupBoxAccounts.TabStop = false;
            this.groupBoxAccounts.Text = "Accounts";
            // 
            // labelTwhint
            // 
            this.labelTwhint.AutoSize = true;
            this.labelTwhint.Location = new System.Drawing.Point(141, 21);
            this.labelTwhint.Name = "labelTwhint";
            this.labelTwhint.Size = new System.Drawing.Size(41, 12);
            this.labelTwhint.TabIndex = 1;
            this.labelTwhint.TabStop = true;
            this.labelTwhint.Text = "Twitter";
            this.labelTwhint.Visible = false;
            this.labelTwhint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelTwhint_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 535);
            this.Controls.Add(this.labelTwState);
            this.Controls.Add(this.buttonSaveSS);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.cbAddTag);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.pbSSPreview);
            this.Controls.Add(this.labelTW);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxAccounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CLVShare";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSSPreview)).EndInit();
            this.groupBoxAccounts.ResumeLayout(false);
            this.groupBoxAccounts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTW;
        private System.Windows.Forms.PictureBox pbSSPreview;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.CheckBox cbAddTag;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Button buttonSaveSS;
        private System.Windows.Forms.Label labelTwState;
        private System.Windows.Forms.GroupBox groupBoxAccounts;
        private System.Windows.Forms.LinkLabel labelTwhint;
    }
}

