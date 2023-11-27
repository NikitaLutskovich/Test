using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class addEmployeeForm : Form
    {
        Database database;

        public addEmployeeForm(Database database)
        {
            InitializeComponent();
            this.database = database;
            database.openConnection();

            // Запрос для извлечения организаций из базы данных
            string query = "SELECT OrganizationID, Name FROM Organizations";

            using (SqlCommand command = new SqlCommand(query, database.getConnection()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Извлекаем значения из столбцов
                            int organizationID = reader.GetInt32(0);
                            string organizationName = reader.GetString(1);

                            // Создаем объект, представляющий организацию
                            Organization organization = new Organization
                            {
                                Name = organizationName
                            };

                            organizationComboBox.Items.Add(organization);
                        }
                    }
                }
            }        
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
                    string query = "INSERT INTO Employees (OrganizationName, Surname, Name, Patronymic, Birthday, PassportSeries, PassportNumber) " +
                                   "VALUES (@OrganizationName, @Surname, @Name, @Patronymic, @Birthday, @PassportSeries, @PassportNumber)";


                    using (SqlCommand command = new SqlCommand(query, database.getConnection()))
                    {
                        // Добавляем параметры для предотвращения SQL-инъекций
                        if (organizationComboBox.SelectedItem is Organization selectedOrganization)
                        {
                            string organizationName = selectedOrganization.Name;
                            command.Parameters.AddWithValue("@OrganizationName", organizationName);
                        }
                        command.Parameters.AddWithValue("@Surname", surnameTextBox.Text);
                        command.Parameters.AddWithValue("@Name", nameTextBox.Text);
                        command.Parameters.AddWithValue("@Patronymic", patronymicTextBox.Text);
                        command.Parameters.AddWithValue("@Birthday", birthdayDateTimePicker.Value);
                        command.Parameters.AddWithValue("@PassportSeries", passportSeriesTextBox.Text);
                        command.Parameters.AddWithValue("@PassportNumber", passportNumberTextBox.Text);

                        // Выполняем запрос
                        command.ExecuteNonQuery();

                        MessageBox.Show("Сотрудник успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (control is TextBox || control is ComboBox)
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
                if (control is TextBox || control is ComboBox)
                {
                    control.ResetText();
                    control.BackColor = Color.White;
                }
            }
        }

    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string OrganizationName { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
    }

}
