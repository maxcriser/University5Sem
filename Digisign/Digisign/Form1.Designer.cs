namespace Digisign
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
            this.sign = new System.Windows.Forms.Button();
            this.verify = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sign
            // 
            this.sign.Location = new System.Drawing.Point(12, 12);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(147, 83);
            this.sign.TabIndex = 1;
            this.sign.Text = "Подписать";
            this.sign.UseVisualStyleBackColor = true;
            this.sign.Click += new System.EventHandler(this.button1_Click);
            // 
            // verify
            // 
            this.verify.Location = new System.Drawing.Point(12, 101);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(147, 79);
            this.verify.TabIndex = 2;
            this.verify.Text = "Проверить";
            this.verify.UseVisualStyleBackColor = true;
            this.verify.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 83);
            this.button3.TabIndex = 3;
            this.button3.Text = "Сгенерировать ключи";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(165, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 79);
            this.button4.TabIndex = 4;
            this.button4.Text = "Импортировать ключи";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 193);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.sign);
            this.Name = "Form1";
            this.Text = "Digisign";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.Button verify;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

