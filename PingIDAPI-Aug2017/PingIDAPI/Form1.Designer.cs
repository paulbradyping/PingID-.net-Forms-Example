namespace PingIDAPI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetUserInfo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GetPropertiesFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartAuth1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StartAuth2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AuthOffLine = new System.Windows.Forms.Button();
            this.AuthOnline = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeviceList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ModelList = new System.Windows.Forms.ListBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.GetDevices = new System.Windows.Forms.Button();
            this.btn_addDevice = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetUserInfo
            // 
            this.GetUserInfo.Enabled = false;
            this.GetUserInfo.Location = new System.Drawing.Point(34, 282);
            this.GetUserInfo.Margin = new System.Windows.Forms.Padding(4);
            this.GetUserInfo.Name = "GetUserInfo";
            this.GetUserInfo.Size = new System.Drawing.Size(154, 55);
            this.GetUserInfo.TabIndex = 1;
            this.GetUserInfo.Text = "Get User Info (GetUserDetails)";
            this.GetUserInfo.UseVisualStyleBackColor = true;
            this.GetUserInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(17, 250);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "PingOne PingID Username (Not the 1st Administrator)";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(279, 195);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(976, 344);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "org_alias";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "use_base64_key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "token";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(504, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "api_version";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(419, 44);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 9;
            this.textBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseClick);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(419, 79);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 22);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(417, 113);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 22);
            this.textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(593, 140);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(63, 22);
            this.textBox5.TabIndex = 12;
            this.textBox5.Text = "4.9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 447);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 13;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // GetPropertiesFile
            // 
            this.GetPropertiesFile.Location = new System.Drawing.Point(21, 41);
            this.GetPropertiesFile.Margin = new System.Windows.Forms.Padding(4);
            this.GetPropertiesFile.Name = "GetPropertiesFile";
            this.GetPropertiesFile.Size = new System.Drawing.Size(236, 28);
            this.GetPropertiesFile.TabIndex = 14;
            this.GetPropertiesFile.Text = "Get PingId Properties File";
            this.GetPropertiesFile.UseVisualStyleBackColor = true;
            this.GetPropertiesFile.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GetPropertiesFile);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(665, 172);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PingID Properties File Info";
            // 
            // StartAuth1
            // 
            this.StartAuth1.Location = new System.Drawing.Point(15, 38);
            this.StartAuth1.Name = "StartAuth1";
            this.StartAuth1.Size = new System.Drawing.Size(334, 57);
            this.StartAuth1.TabIndex = 18;
            this.StartAuth1.Text = "Start Authenticate Online";
            this.StartAuth1.UseVisualStyleBackColor = true;
            this.StartAuth1.Visible = false;
            this.StartAuth1.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StartAuth2);
            this.groupBox2.Controls.Add(this.StartAuth1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(61, 580);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 230);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Start Authentication";
            // 
            // StartAuth2
            // 
            this.StartAuth2.Location = new System.Drawing.Point(15, 128);
            this.StartAuth2.Name = "StartAuth2";
            this.StartAuth2.Size = new System.Drawing.Size(334, 58);
            this.StartAuth2.TabIndex = 19;
            this.StartAuth2.Text = "Start Authenticate Call (Gets a Session ID)";
            this.StartAuth2.UseVisualStyleBackColor = true;
            this.StartAuth2.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AuthOffLine);
            this.groupBox3.Controls.Add(this.AuthOnline);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(517, 580);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 229);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Authenticate ";
            // 
            // AuthOffLine
            // 
            this.AuthOffLine.Location = new System.Drawing.Point(86, 128);
            this.AuthOffLine.Name = "AuthOffLine";
            this.AuthOffLine.Size = new System.Drawing.Size(191, 66);
            this.AuthOffLine.TabIndex = 1;
            this.AuthOffLine.Text = "Offline with sessionId";
            this.AuthOffLine.UseVisualStyleBackColor = true;
            this.AuthOffLine.Click += new System.EventHandler(this.button6_Click);
            // 
            // AuthOnline
            // 
            this.AuthOnline.Location = new System.Drawing.Point(87, 38);
            this.AuthOnline.Name = "AuthOnline";
            this.AuthOnline.Size = new System.Drawing.Size(191, 57);
            this.AuthOnline.TabIndex = 0;
            this.AuthOnline.Text = "Online Without sessionId";
            this.AuthOnline.UseVisualStyleBackColor = true;
            this.AuthOnline.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(261, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 123);
            this.panel1.TabIndex = 22;
            this.panel1.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(115, 85);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(113, 25);
            this.button7.TabIndex = 3;
            this.button7.Text = "Ok";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(75, 47);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(192, 22);
            this.textBox6.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the OTP Value from App SMS or Voice ";
            // 
            // DeviceList
            // 
            this.DeviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceList.FormattingEnabled = true;
            this.DeviceList.ItemHeight = 16;
            this.DeviceList.Location = new System.Drawing.Point(18, 46);
            this.DeviceList.Name = "DeviceList";
            this.DeviceList.Size = new System.Drawing.Size(154, 80);
            this.DeviceList.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.ModelList);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.DeviceList);
            this.panel2.Location = new System.Drawing.Point(415, 233);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 175);
            this.panel2.TabIndex = 24;
            this.panel2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // ModelList
            // 
            this.ModelList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModelList.FormattingEnabled = true;
            this.ModelList.ItemHeight = 16;
            this.ModelList.Location = new System.Drawing.Point(171, 46);
            this.ModelList.Name = "ModelList";
            this.ModelList.Size = new System.Drawing.Size(277, 80);
            this.ModelList.TabIndex = 26;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(42, 140);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(113, 25);
            this.button8.TabIndex = 25;
            this.button8.Text = "Ok";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Device to use";
            // 
            // GetDevices
            // 
            this.GetDevices.Location = new System.Drawing.Point(279, 536);
            this.GetDevices.Name = "GetDevices";
            this.GetDevices.Size = new System.Drawing.Size(221, 38);
            this.GetDevices.TabIndex = 25;
            this.GetDevices.Text = "Get Devices  ";
            this.GetDevices.UseVisualStyleBackColor = true;
            this.GetDevices.Visible = false;
            this.GetDevices.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_addDevice
            // 
            this.btn_addDevice.Enabled = false;
            this.btn_addDevice.Location = new System.Drawing.Point(37, 353);
            this.btn_addDevice.Name = "btn_addDevice";
            this.btn_addDevice.Size = new System.Drawing.Size(154, 55);
            this.btn_addDevice.TabIndex = 26;
            this.btn_addDevice.Text = "Add Device (StartOfflinePairing)";
            this.btn_addDevice.UseVisualStyleBackColor = true;
            this.btn_addDevice.Click += new System.EventHandler(this.btn_addDevice_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.radioButton3);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Location = new System.Drawing.Point(261, 362);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 123);
            this.panel3.TabIndex = 27;
            this.panel3.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(11, 84);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(69, 21);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "EMAIL";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 21);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "VOICE";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 21);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SMS";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(81, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(238, 50);
            this.label9.TabIndex = 1;
            this.label9.Text = "Select Device Type and Enter the Info ";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(101, 56);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(214, 22);
            this.textBox7.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 811);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btn_addDevice);
            this.Controls.Add(this.GetDevices);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GetUserInfo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "PingID .Net Test Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GetUserInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button GetPropertiesFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StartAuth1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StartAuth2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AuthOffLine;
        private System.Windows.Forms.Button AuthOnline;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox DeviceList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox ModelList;
        private System.Windows.Forms.Button GetDevices;
        private System.Windows.Forms.Button btn_addDevice;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

