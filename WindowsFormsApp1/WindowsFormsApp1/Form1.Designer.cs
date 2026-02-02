namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.validationFormControl1 = new WindowsFormsApp1.ValidationFormControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.txtUserInfo = new System.Windows.Forms.TextBox();
            this.btnClearInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // validationFormControl1
            // 
            this.validationFormControl1.Location = new System.Drawing.Point(10, 20);
            this.validationFormControl1.Name = "validationFormControl1";
            this.validationFormControl1.Size = new System.Drawing.Size(330, 300);
            this.validationFormControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.validationFormControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 330);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Форма ввода данных";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(380, 12);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(155, 13);
            this.lblUserInfo.TabIndex = 2;
            this.lblUserInfo.Text = "Информация о пользователе:";
            // 
            // txtUserInfo
            // 
            this.txtUserInfo.Location = new System.Drawing.Point(380, 35);
            this.txtUserInfo.Multiline = true;
            this.txtUserInfo.Name = "txtUserInfo";
            this.txtUserInfo.ReadOnly = true;
            this.txtUserInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserInfo.Size = new System.Drawing.Size(400, 250);
            this.txtUserInfo.TabIndex = 3;
            // 
            // btnClearInfo
            // 
            this.btnClearInfo.Location = new System.Drawing.Point(380, 295);
            this.btnClearInfo.Name = "btnClearInfo";
            this.btnClearInfo.Size = new System.Drawing.Size(150, 30);
            this.btnClearInfo.TabIndex = 4;
            this.btnClearInfo.Text = "Очистить информацию";
            this.btnClearInfo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnClearInfo);
            this.Controls.Add(this.txtUserInfo);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Регистрация пользователя";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsApp1.ValidationFormControl validationFormControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.TextBox txtUserInfo;
        private System.Windows.Forms.Button btnClearInfo;
    }
}

