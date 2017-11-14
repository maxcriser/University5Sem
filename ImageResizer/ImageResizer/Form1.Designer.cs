namespace ImageResizer
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
            this.selectedPicturebox = new System.Windows.Forms.PictureBox();
            this.resultPicturebox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.resizeBar = new System.Windows.Forms.TrackBar();
            this.resizeValueTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedPicturebox
            // 
            this.selectedPicturebox.Location = new System.Drawing.Point(12, 12);
            this.selectedPicturebox.Name = "selectedPicturebox";
            this.selectedPicturebox.Size = new System.Drawing.Size(251, 225);
            this.selectedPicturebox.TabIndex = 0;
            this.selectedPicturebox.TabStop = false;
            // 
            // resultPicturebox
            // 
            this.resultPicturebox.Location = new System.Drawing.Point(269, 12);
            this.resultPicturebox.Name = "resultPicturebox";
            this.resultPicturebox.Size = new System.Drawing.Size(474, 419);
            this.resultPicturebox.TabIndex = 1;
            this.resultPicturebox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resizeBar
            // 
            this.resizeBar.Location = new System.Drawing.Point(13, 286);
            this.resizeBar.Minimum = -10;
            this.resizeBar.Name = "resizeBar";
            this.resizeBar.Size = new System.Drawing.Size(250, 45);
            this.resizeBar.TabIndex = 3;
            this.resizeBar.Scroll += new System.EventHandler(this.resizeBar_Scroll);
            // 
            // resizeValueTextBox
            // 
            this.resizeValueTextBox.Location = new System.Drawing.Point(88, 321);
            this.resizeValueTextBox.Name = "resizeValueTextBox";
            this.resizeValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.resizeValueTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 467);
            this.Controls.Add(this.resizeValueTextBox);
            this.Controls.Add(this.resizeBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultPicturebox);
            this.Controls.Add(this.selectedPicturebox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.selectedPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox selectedPicturebox;
        private System.Windows.Forms.PictureBox resultPicturebox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar resizeBar;
        private System.Windows.Forms.TextBox resizeValueTextBox;
    }
}

