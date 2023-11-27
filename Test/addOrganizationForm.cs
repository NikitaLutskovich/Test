using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Test
{
    public partial class addOrganizationForm : Form
    {
        Database database;
        public addOrganizationForm(Database database)
        {
            InitializeComponent();
            this.database = database;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            bool flag = checkControls();

            if (flag == false)
            {              
                try
                {
                    database.openConnection();
                    string query = "INSERT INTO Organizations (Name, TIN, ActualAddress, LegalAddress)" +
                                   "VALUES (@Name, @TIN, @ActualAddress, @LegalAddress)";

                    using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                    {
                        // Добавляем параметры для предотвращения SQL-инъекций
                        command.Parameters.AddWithValue("@Name", nameTextBox.Text);
                        command.Parameters.AddWithValue("@TIN", tinTextBox.Text);
                        command.Parameters.AddWithValue("@ActualAddress", actualAddressTextBox.Text);
                        command.Parameters.AddWithValue("@LegalAddress", legalAddressTextBox.Text);

                        // Выполняем запрос
                        command.ExecuteNonQuery();

                        MessageBox.Show("Организация успешно добавлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    database.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                clearControls();
            }
            else
            {
                MessageBox.Show("Присутствуют незаполненные поля. Повторите ввод.");
            }
            
        }

        private bool checkControls()
        {
            int count = 0;

            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    if (control.Text == "")
                    {
                        control.BackColor = Color.LightPink;
                        count++;
                    }
                    else
                    {
                        control.BackColor = Color.White;
                    }
                }
            }

            return Convert.ToBoolean(count);
        }

        private void clearControls()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    control.ResetText();
                    control.BackColor = Color.White;
                }
            }
        }
    }

    public class Organization
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string TIN { get; set; }
        public string ActualAddress { get; set; }
        public string LegalAddress { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
