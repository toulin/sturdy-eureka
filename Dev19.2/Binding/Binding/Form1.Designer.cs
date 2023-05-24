namespace Binding
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
            this.components = new System.ComponentModel.Container();
            this.MyLabel = new DevExpress.XtraEditors.LabelControl();
            this.DoSomething = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.myClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MyLabel
            // 
            this.MyLabel.Location = new System.Drawing.Point(41, 79);
            this.MyLabel.Name = "MyLabel";
            this.MyLabel.Size = new System.Drawing.Size(70, 14);
            this.MyLabel.TabIndex = 0;
            this.MyLabel.Text = "labelControl1";
            // 
            // DoSomething
            // 
            this.DoSomething.Location = new System.Drawing.Point(41, 12);
            this.DoSomething.Name = "DoSomething";
            this.DoSomething.Size = new System.Drawing.Size(120, 50);
            this.DoSomething.TabIndex = 1;
            this.DoSomething.Text = "simpleButton1";
            this.DoSomething.Click += new System.EventHandler(this.DoSomething_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myClassBindingSource, "Time", true));
            this.label1.Location = new System.Drawing.Point(39, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // myClassBindingSource
            // 
            this.myClassBindingSource.DataSource = typeof(Binding.MyClass);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DoSomething);
            this.Controls.Add(this.MyLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.myClassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl MyLabel;
        private DevExpress.XtraEditors.SimpleButton DoSomething;
        private System.Windows.Forms.BindingSource myClassBindingSource;
        private System.Windows.Forms.Label label1;
    }
}

