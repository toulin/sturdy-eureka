namespace 正規表示式
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rdoIsMatch = new System.Windows.Forms.RadioButton();
            this.rdoMatchs = new System.Windows.Forms.RadioButton();
            this.tOutput = new System.Windows.Forms.TextBox();
            this.tInput = new System.Windows.Forms.TextBox();
            this.patternLst = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bMatch = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tOutput2 = new System.Windows.Forms.TextBox();
            this.tPattern = new System.Windows.Forms.TextBox();
            this.tInput2 = new System.Windows.Forms.TextBox();
            this.bTestR = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1080, 720);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rdoIsMatch);
            this.tabPage1.Controls.Add(this.rdoMatchs);
            this.tabPage1.Controls.Add(this.tOutput);
            this.tabPage1.Controls.Add(this.tInput);
            this.tabPage1.Controls.Add(this.patternLst);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1072, 688);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Match";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rdoIsMatch
            // 
            this.rdoIsMatch.AutoSize = true;
            this.rdoIsMatch.Location = new System.Drawing.Point(150, 48);
            this.rdoIsMatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoIsMatch.Name = "rdoIsMatch";
            this.rdoIsMatch.Size = new System.Drawing.Size(90, 22);
            this.rdoIsMatch.TabIndex = 10;
            this.rdoIsMatch.Text = "IsMatch";
            this.rdoIsMatch.UseVisualStyleBackColor = true;
            // 
            // rdoMatchs
            // 
            this.rdoMatchs.AutoSize = true;
            this.rdoMatchs.Checked = true;
            this.rdoMatchs.Location = new System.Drawing.Point(28, 48);
            this.rdoMatchs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoMatchs.Name = "rdoMatchs";
            this.rdoMatchs.Size = new System.Drawing.Size(84, 22);
            this.rdoMatchs.TabIndex = 9;
            this.rdoMatchs.TabStop = true;
            this.rdoMatchs.Text = "Matchs";
            this.rdoMatchs.UseVisualStyleBackColor = true;
            // 
            // tOutput
            // 
            this.tOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tOutput.Location = new System.Drawing.Point(28, 519);
            this.tOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tOutput.Multiline = true;
            this.tOutput.Name = "tOutput";
            this.tOutput.Size = new System.Drawing.Size(1002, 128);
            this.tOutput.TabIndex = 8;
            // 
            // tInput
            // 
            this.tInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tInput.Location = new System.Drawing.Point(28, 96);
            this.tInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tInput.Multiline = true;
            this.tInput.Name = "tInput";
            this.tInput.Size = new System.Drawing.Size(1002, 134);
            this.tInput.TabIndex = 7;
            this.tInput.Text = "[wty],tyeh[67hj],rffv,[7]";
            // 
            // patternLst
            // 
            this.patternLst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patternLst.FormattingEnabled = true;
            this.patternLst.ItemHeight = 18;
            this.patternLst.Location = new System.Drawing.Point(28, 260);
            this.patternLst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.patternLst.Name = "patternLst";
            this.patternLst.Size = new System.Drawing.Size(1002, 220);
            this.patternLst.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(930, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bMatch);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.tOutput2);
            this.tabPage2.Controls.Add(this.tPattern);
            this.tabPage2.Controls.Add(this.tInput2);
            this.tabPage2.Controls.Add(this.bTestR);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1072, 688);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bMatch
            // 
            this.bMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bMatch.Location = new System.Drawing.Point(806, 22);
            this.bMatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bMatch.Name = "bMatch";
            this.bMatch.Size = new System.Drawing.Size(102, 50);
            this.bMatch.TabIndex = 12;
            this.bMatch.Text = "Match";
            this.bMatch.UseVisualStyleBackColor = true;
            this.bMatch.Click += new System.EventHandler(this.bMatch_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(675, 81);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 50);
            this.button2.TabIndex = 11;
            this.button2.Text = "IsMatch";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tOutput2
            // 
            this.tOutput2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tOutput2.Location = new System.Drawing.Point(12, 381);
            this.tOutput2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tOutput2.Multiline = true;
            this.tOutput2.Name = "tOutput2";
            this.tOutput2.Size = new System.Drawing.Size(625, 223);
            this.tOutput2.TabIndex = 10;
            // 
            // tPattern
            // 
            this.tPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tPattern.Location = new System.Drawing.Point(12, 183);
            this.tPattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tPattern.Multiline = true;
            this.tPattern.Name = "tPattern";
            this.tPattern.Size = new System.Drawing.Size(625, 134);
            this.tPattern.TabIndex = 9;
            this.tPattern.Text = "[0-9]{4}![^0-9]+[0-9]{9}[0-9]{4}";
            // 
            // tInput2
            // 
            this.tInput2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tInput2.Location = new System.Drawing.Point(12, 22);
            this.tInput2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tInput2.Multiline = true;
            this.tInput2.Name = "tInput2";
            this.tInput2.Size = new System.Drawing.Size(625, 134);
            this.tInput2.TabIndex = 8;
            this.tInput2.Text = "1101!台泥12345678912342002!中鋼1234567891234";
            // 
            // bTestR
            // 
            this.bTestR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bTestR.Location = new System.Drawing.Point(675, 22);
            this.bTestR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bTestR.Name = "bTestR";
            this.bTestR.Size = new System.Drawing.Size(102, 50);
            this.bTestR.TabIndex = 6;
            this.bTestR.Text = "Matches";
            this.bTestR.UseVisualStyleBackColor = true;
            this.bTestR.Click += new System.EventHandler(this.bTestR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tOutput;
        private System.Windows.Forms.TextBox tInput;
        private System.Windows.Forms.ListBox patternLst;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdoIsMatch;
        private System.Windows.Forms.RadioButton rdoMatchs;
        private System.Windows.Forms.TextBox tInput2;
        private System.Windows.Forms.Button bTestR;
        private System.Windows.Forms.TextBox tPattern;
        private System.Windows.Forms.TextBox tOutput2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bMatch;
    }
}

