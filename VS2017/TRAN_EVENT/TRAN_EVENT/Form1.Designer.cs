namespace TRAN_EVENT
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bReadyData = new System.Windows.Forms.Button();
            this.bRestart = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bReadyData
            // 
            this.bReadyData.Location = new System.Drawing.Point(12, 12);
            this.bReadyData.Name = "bReadyData";
            this.bReadyData.Size = new System.Drawing.Size(65, 26);
            this.bReadyData.TabIndex = 1;
            this.bReadyData.Text = "Ready";
            this.bReadyData.UseVisualStyleBackColor = true;
            this.bReadyData.Click += new System.EventHandler(this.bReadyData_Click);
            // 
            // bRestart
            // 
            this.bRestart.Location = new System.Drawing.Point(12, 58);
            this.bRestart.Name = "bRestart";
            this.bRestart.Size = new System.Drawing.Size(65, 26);
            this.bRestart.TabIndex = 2;
            this.bRestart.Text = "Restart";
            this.bRestart.UseVisualStyleBackColor = true;
            this.bRestart.Click += new System.EventHandler(this.bRestart_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtDisplay.Location = new System.Drawing.Point(298, 0);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay.Size = new System.Drawing.Size(477, 613);
            this.txtDisplay.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 613);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.bRestart);
            this.Controls.Add(this.bReadyData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bReadyData;
        private System.Windows.Forms.Button bRestart;
        private System.Windows.Forms.TextBox txtDisplay;
    }
}

