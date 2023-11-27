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
using System.IO;
using static System.Net.WebRequestMethods;

namespace Test
{
    public partial class menuForm : Form
    {

        Database database;

        public menuForm()
        {
            InitializeComponent();
            database = new Database();
        }

        private void addOrganizationButton_Click(object sender, EventArgs e)
        {
            addOrganizationForm organizationForm = new addOrganizationForm(database);
            this.Hide();
            organizationForm.FormClosed += (s, args) => this.Show(); // Обработчик события закрытия addOrganizationForm
            organizationForm.Show();
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            addEmployeeForm employeeForm = new addEmployeeForm(database);
            this.Hide();
            employeeForm.FormClosed += (s, args) => this.Show(); // Обработчик события закрытия addEmployeeForm
            employeeForm.Show();
        }

        private void exportDataButton_Click(object sender, EventArgs e)
        {
            // Получаем данные из базы данных
            List<Organization> organizations = database.GetOrganizationsFromDatabase();
            List<Employee> employees = database.GetEmployeesFromDatabase();

            string folderPath = "..\\..\\Export";

            try
            {
                // Проверяем существование папки перед созданием
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Экспортируем данные в CSV файлы
                Csv.ExportOrganizationsToCsv(organizations, "..\\..\\Export\\organizations.csv");
                Csv.ExportEmployeesToCsv(employees, "..\\..\\Export\\employees.csv");

                MessageBox.Show("Экспорт данных выполнен успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void importDataButton_Click(object sender, EventArgs e)
        {
            string folderPath = "..\\..\\Import";

            // Проверяем существование папки
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                MessageBox.Show("Папка Import пуста. Добавьте файлы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string organizationsCsvPath = "..\\..\\Import\\organizations.csv";
                string employeesCsvPath = "..\\..\\Import\\employees.csv";

                if (!System.IO.File.Exists(organizationsCsvPath) || !System.IO.File.Exists(employeesCsvPath))
                {
                    MessageBox.Show("Не достает файлов organizations.csv или employees.csv.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    // Импорт данных
                    List<Organization> importedOrganizations = Csv.ImportOrganizationsFromCsv(organizationsCsvPath);
                    List<Employee> importedEmployees = Csv.ImportEmployeesFromCsv(employeesCsvPath);

                    database.AddOrganizationsToDatabase(importedOrganizations);
                    database.AddEmployeesToDatabase(importedEmployees);

                    MessageBox.Show("Импорт данных выполнен успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }
    }
}
