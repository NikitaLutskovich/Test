namespace Test
{
    partial class menuForm
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
            this.addOrganizationButton = new System.Windows.Forms.Button();
            this.addEmployeeButton = new System.Windows.Forms.Button();
            this.exportDataButton = new System.Windows.Forms.Button();
            this.importDataButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addOrganizationButton
            // 
            this.addOrganizationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addOrganizationButton.Location = new System.Drawing.Point(12, 12);
            this.addOrganizationButton.Name = "addOrganizationButton";
            this.addOrganizationButton.Size = new System.Drawing.Size(183, 23);
            this.addOrganizationButton.TabIndex = 0;
            this.addOrganizationButton.Text = "Добавить организацию";
            this.addOrganizationButton.UseVisualStyleBackColor = true;
            this.addOrganizationButton.Click += new System.EventHandler(this.addOrganizationButton_Click);
            // 
            // addEmployeeButton
            // 
            this.addEmployeeButton.Location = new System.Drawing.Point(12, 41);
            this.addEmployeeButton.Name = "addEmployeeButton";
            this.addEmployeeButton.Size = new System.Drawing.Size(183, 23);
            this.addEmployeeButton.TabIndex = 1;
            this.addEmployeeButton.Text = "Добавить сотрудника";
            this.addEmployeeButton.UseVisualStyleBackColor = true;
            this.addEmployeeButton.Click += new System.EventHandler(this.addEmployeeButton_Click);
            // 
            // exportDataButton
            // 
            this.exportDataButton.Location = new System.Drawing.Point(12, 99);
            this.exportDataButton.Name = "exportDataButton";
            this.exportDataButton.Size = new System.Drawing.Size(183, 23);
            this.exportDataButton.TabIndex = 2;
            this.exportDataButton.Text = "Экспортироать данные";
            this.exportDataButton.UseVisualStyleBackColor = true;
            this.exportDataButton.Click += new System.EventHandler(this.exportDataButton_Click);
            // 
            // importDataButton
            // 
            this.importDataButton.Location = new System.Drawing.Point(12, 128);
            this.importDataButton.Name = "importDataButton";
            this.importDataButton.Size = new System.Drawing.Size(183, 23);
            this.importDataButton.TabIndex = 3;
            this.importDataButton.Text = "Импортировать данные";
            this.importDataButton.UseVisualStyleBackColor = true;
            this.importDataButton.Click += new System.EventHandler(this.importDataButton_Click);
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 162);
            this.Controls.Add(this.importDataButton);
            this.Controls.Add(this.exportDataButton);
            this.Controls.Add(this.addEmployeeButton);
            this.Controls.Add(this.addOrganizationButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "menuForm";
            this.Text = "Меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addOrganizationButton;
        private System.Windows.Forms.Button addEmployeeButton;
        private System.Windows.Forms.Button exportDataButton;
        private System.Windows.Forms.Button importDataButton;
    }
}

