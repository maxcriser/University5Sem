namespace CRCCalculation
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
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.compareButton = new System.Windows.Forms.Button();
            this.selectedFolderTextView = new System.Windows.Forms.TextBox();
            this.selftCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(13, 13);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(187, 23);
            this.selectFolderButton.TabIndex = 0;
            this.selectFolderButton.Text = "Select folder";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(13, 43);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(187, 23);
            this.compareButton.TabIndex = 1;
            this.compareButton.Text = "Compare with etalon";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // selectedFolderTextView
            // 
            this.selectedFolderTextView.Location = new System.Drawing.Point(13, 73);
            this.selectedFolderTextView.Name = "selectedFolderTextView";
            this.selectedFolderTextView.Size = new System.Drawing.Size(726, 20);
            this.selectedFolderTextView.TabIndex = 2;
            // 
            // selftCheck
            // 
            this.selftCheck.Location = new System.Drawing.Point(207, 13);
            this.selftCheck.Name = "selftCheck";
            this.selftCheck.Size = new System.Drawing.Size(532, 54);
            this.selftCheck.TabIndex = 3;
            this.selftCheck.Text = "START SELF CHECK";
            this.selftCheck.UseVisualStyleBackColor = true;
            this.selftCheck.Click += new System.EventHandler(this.selftCheck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 106);
            this.Controls.Add(this.selftCheck);
            this.Controls.Add(this.selectedFolderTextView);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.selectFolderButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.TextBox selectedFolderTextView;
        private System.Windows.Forms.Button selftCheck;
    }
}

