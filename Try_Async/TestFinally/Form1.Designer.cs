
namespace TestFinally
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
            this.UsingFinallyButton = new System.Windows.Forms.Button();
            this.WithoutFinallyButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SystemTimerUsingFinallyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsingFinallyButton
            // 
            this.UsingFinallyButton.Location = new System.Drawing.Point(18, 106);
            this.UsingFinallyButton.Name = "UsingFinallyButton";
            this.UsingFinallyButton.Size = new System.Drawing.Size(270, 56);
            this.UsingFinallyButton.TabIndex = 0;
            this.UsingFinallyButton.Text = "TestTimerUsingFinally";
            this.UsingFinallyButton.UseVisualStyleBackColor = true;
            this.UsingFinallyButton.Click += new System.EventHandler(this.UsingFinallyButton_Click);
            // 
            // WithoutFinallyButton
            // 
            this.WithoutFinallyButton.Location = new System.Drawing.Point(18, 22);
            this.WithoutFinallyButton.Name = "WithoutFinallyButton";
            this.WithoutFinallyButton.Size = new System.Drawing.Size(270, 56);
            this.WithoutFinallyButton.TabIndex = 1;
            this.WithoutFinallyButton.Text = "TestTimerWithoutFinally";
            this.WithoutFinallyButton.UseVisualStyleBackColor = true;
            this.WithoutFinallyButton.Click += new System.EventHandler(this.WithoutFinallyButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 56);
            this.button1.TabIndex = 2;
            this.button1.Text = "SystemTimerWithoutFinally";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SystemTimerUsingFinallyButton
            // 
            this.SystemTimerUsingFinallyButton.Location = new System.Drawing.Point(18, 314);
            this.SystemTimerUsingFinallyButton.Name = "SystemTimerUsingFinallyButton";
            this.SystemTimerUsingFinallyButton.Size = new System.Drawing.Size(270, 56);
            this.SystemTimerUsingFinallyButton.TabIndex = 3;
            this.SystemTimerUsingFinallyButton.Text = "SystemTimerUsingFinally";
            this.SystemTimerUsingFinallyButton.UseVisualStyleBackColor = true;
            this.SystemTimerUsingFinallyButton.Click += new System.EventHandler(this.SystemTimerUsingFinallyButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 389);
            this.Controls.Add(this.SystemTimerUsingFinallyButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WithoutFinallyButton);
            this.Controls.Add(this.UsingFinallyButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UsingFinallyButton;
        private System.Windows.Forms.Button WithoutFinallyButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SystemTimerUsingFinallyButton;
    }
}

