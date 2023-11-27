namespace Test
{
    partial class addOrganizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tinTextBox = new System.Windows.Forms.TextBox();
            this.legalAddressTextBox = new System.Windows.Forms.TextBox();
            this.actualAddressTextBox = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(10, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(250, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ИНН:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Факт. адрес:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Юр. адрес:";
            // 
            // tinTextBox
            // 
            this.tinTextBox.Location = new System.Drawing.Point(10, 76);
            this.tinTextBox.Name = "tinTextBox";
            this.tinTextBox.Size = new System.Drawing.Size(250, 20);
            this.tinTextBox.TabIndex = 3;
            // 
            // legalAddressTextBox
            // 
            this.legalAddressTextBox.Location = new System.Drawing.Point(10, 176);
            this.legalAddressTextBox.Name = "legalAddressTextBox";
            this.legalAddressTextBox.Size = new System.Drawing.Size(250, 20);
            this.legalAddressTextBox.TabIndex = 7;
            // 
            // actualAddressTextBox
            // 
            this.actualAddressTextBox.Location = new System.Drawing.Point(10, 126);
            this.actualAddressTextBox.Name = "actualAddressTextBox";
            this.actualAddressTextBox.Size = new System.Drawing.Size(250, 20);
            this.actualAddressTextBox.TabIndex = 5;
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(10, 210);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(83, 23);
            this.confirm.TabIndex = 8;
            this.confirm.Text = "Подтвердить";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(177, 210);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(83, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "Отменить";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // addOrganizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 241);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.actualAddressTextBox);
            this.Controls.Add(this.legalAddressTextBox);
            this.Controls.Add(this.tinTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "addOrganizationForm";
            this.Text = "Организация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tinTextBox;
        private System.Windows.Forms.TextBox legalAddressTextBox;
        private System.Windows.Forms.TextBox actualAddressTextBox;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
    }
}