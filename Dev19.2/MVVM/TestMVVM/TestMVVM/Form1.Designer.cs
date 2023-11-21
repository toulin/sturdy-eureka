namespace TestMVVM
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
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
            this.TreePanel = new DevExpress.XtraEditors.PanelControl();
            this.ListPanel = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TreePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // TreePanel
            // 
            this.TreePanel.Location = new System.Drawing.Point(21, 62);
            this.TreePanel.Name = "TreePanel";
            this.TreePanel.Size = new System.Drawing.Size(250, 322);
            this.TreePanel.TabIndex = 0;
            // 
            // ListPanel
            // 
            this.ListPanel.Location = new System.Drawing.Point(371, 62);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(250, 322);
            this.ListPanel.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(39, 19);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(73, 32);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.ListPanel);
            this.Controls.Add(this.TreePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TreePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl TreePanel;
        private DevExpress.XtraEditors.PanelControl ListPanel;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

