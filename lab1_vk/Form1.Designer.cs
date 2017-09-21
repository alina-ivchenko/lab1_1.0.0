namespace lab1_vk
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tBInfo = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeUpdate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tBInfo
            // 
            this.tBInfo.Location = new System.Drawing.Point(8, 13);
            this.tBInfo.Multiline = true;
            this.tBInfo.Name = "tBInfo";
            this.tBInfo.Size = new System.Drawing.Size(266, 171);
            this.tBInfo.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 213);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(132, 13);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Последнее обновление: ";
            // 
            // lblTimeUpdate
            // 
            this.lblTimeUpdate.AutoSize = true;
            this.lblTimeUpdate.Location = new System.Drawing.Point(150, 213);
            this.lblTimeUpdate.Name = "lblTimeUpdate";
            this.lblTimeUpdate.Size = new System.Drawing.Size(0, 13);
            this.lblTimeUpdate.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblTimeUpdate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.tBInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBInfo;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeUpdate;
    }
}

