using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Test
{
    public class Database
    {
        SqlConnection databaseConnection;

        public Database()
        {
            string serverConnectionString = "Data Source=DESKTOP-3BJ71UK\\SQLEXPRESS;" +    // Заменить на свой Data Source
                                            "Integrated Security=True";

            string databaseConnectionString = "Data Source=DESKTOP-3BJ71UK\\SQLEXPRESS;" +  // Заменить на свой Data Source
                                              "Initial Catalog=DatabaseName;" +
                                              "Integrated Security=True";

            checkAndCreateDatabase(serverConnectionString);
            checkAndCreateTables(databaseConnectionString);

            databaseConnection = new SqlConnection(databaseConnectionString);
        }
            
        private void checkAndCreateDatabase(string serverConnectionString)
        {
            try
            {
                using (SqlConnection serverConnection = new SqlConnection(serverConnectionString))
                {
                    serverConnection.Open();

                    // Чтение SQL-скрипта из файла
                    string scriptPath = Path.GetFullPath("..\\..\\createDatabase.sql");
                    string sqlScript = File.ReadAllText(scriptPath);

                    // Создаем команду и устанавливаем соединение
                    using (SqlCommand sqlCommand = new SqlCommand(sqlScript, serverConnection))
                    {
                        // Выполняем SQL-скрипт
                        sqlCommand.ExecuteNonQuery();
                    }

                    serverConnection.Close();
                    Console.WriteLine("checkAndCreateDatabase completed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void checkAndCreateTables(string databaseConnectionString)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(databaseConnectionString))
                {
                    databaseConnection.Open();

                    // Чтение SQL-скрипта из файла
                    string scriptPath = Path.GetFullPath("..\\..\\createTables.sql"); ;
                    string sqlScript = File.ReadAllText(scriptPath);

                    // Создаем команду и устанавливаем соединение
                    using (SqlCommand sqlCommand = new SqlCommand(sqlScript, databaseConnection))
                    {
                        // Выполняем SQL-скрипт
                        sqlCommand.ExecuteNonQuery();
                    }

                    databaseConnection.Close();
                    Console.WriteLine("checkAndCreateTables completed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void openConnection()
        {
            if (databaseConnection.State == System.Data.ConnectionState.Closed)
            {
                databaseConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (databaseConnection.State == System.Data.ConnectionState.Open)
            {
                databaseConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return databaseConnection;
        }

        // Экспорт организаций из базы данных
        public List<Organization> GetOrganizationsFromDatabase()
        {
            List<Organization> organizations = new List<Organization>();

            this.openConnection();

            string query = "SELECT * FROM Organizations";
            using (SqlCommand command = new SqlCommand(query, databaseConnection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    organizations.Add(new Organization
                    {
                        OrganizationID = (int)reader["OrganizationID"],
                        Name = (string)reader["Name"],
                        TIN = (string)reader["TIN"],
                        ActualAddress = (string)reader["ActualAddress"],
                        LegalAddress = (string)reader["LegalAddress"]
                    });
                }
            }

            this.closeConnection();

            return organizations;
        }

        // Экспорт сотрудников из базы данных
        public List<Employee> GetEmployeesFromDatabase()
        {
            List<Employee> employees = new List<Employee>();

            this.openConnection();

            string query = "SELECT * FROM Employees";
            using (SqlCommand command = new SqlCommand(query, databaseConnection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        OrganizationName = (string)reader["OrganizationName"],
                        Surname = (string)reader["Surname"],
                        Name = (string)reader["Name"],
                        Patronymic = (string)reader["Patronymic"],
                        Birthday = (DateTime)reader["Birthday"],
                        PassportSeries = (string)reader["PassportSeries"],
                        PassportNumber = (string)reader["PassportNumber"]
                    });
                }
            }

            this.closeConnection();

            return employees;
        }

        // Импорт организаций в базу данных
        public void AddOrganizationsToDatabase(List<Organization> organizations)
        {
            try
            {
                this.openConnection();

                foreach (var organization in organizations)
                    {
                        string query = "INSERT INTO Organizations (Name, TIN, ActualAddress, LegalAddress)" +
                                       "VALUES (@Name, @TIN, @ActualAddress, @LegalAddress)";

                        using (SqlCommand command = new SqlCommand(query, databaseConnection))
                        {
                            command.Parameters.AddWithValue("@Name", organization.Name);
                            command.Parameters.AddWithValue("@TIN", organization.TIN);
                            command.Parameters.AddWithValue("@ActualAddress", organization.ActualAddress);
                            command.Parameters.AddWithValue("@LegalAddress", organization.LegalAddress);

                            command.ExecuteNonQuery();
                        }
                    }

                this.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении организаций: {ex.Message}");
            }
        }

        // Импорт сотрудников в базу данных
        public void AddEmployeesToDatabase(List<Employee> employees)
        {
            try
            {
                this.openConnection();

                    foreach (var employee in employees)
                    {
                        string query = "INSERT INTO Employees (OrganizationName, Surname, Name, Patronymic, Birthday, PassportSeries, PassportNumber)" +
                                       "VALUES (@OrganizationName, @Surname, @Name, @Patronymic, @Birthday, @PassportSeries, @PassportNumber)";

                        using (SqlCommand command = new SqlCommand(query, databaseConnection))
                        {
                            command.Parameters.AddWithValue("@OrganizationName", employee.OrganizationName);
                            command.Parameters.AddWithValue("@Surname", employee.Surname);
                            command.Parameters.AddWithValue("@Name", employee.Name);
                            command.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                            command.Parameters.AddWithValue("@Birthday", employee.Birthday);
                            command.Parameters.AddWithValue("@PassportSeries", employee.PassportSeries);
                            command.Parameters.AddWithValue("@PassportNumber", employee.PassportNumber);

                            command.ExecuteNonQuery();
                        }
                    }

                this.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении сотрудников: {ex.Message}");
            }
        }
    }
}
