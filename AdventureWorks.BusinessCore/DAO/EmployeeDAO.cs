using AdventureWorks.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BusinessCore.DAO
{
    public class EmployeeDAO
    {
        private const string CONNECTION_STRING = @"Server=tcp:cfq4uoqy8a.database.windows.net,1433;Initial Catalog=AdventureWorks2012;Persist Security Info=False;User ID=mjsonAdmin;Password=Solstice123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<Employee> GetAllEmployees()
        {
            List<Employee> returnEmployees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                SqlDataReader reader = null;

                try
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.usp_Employee_SelectAll", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // execute the command
                    reader = cmd.ExecuteReader();

                    // iterate through results, printing each to console
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Int32.Parse(reader["BusinessEntityID"].ToString());
                        employee.NationalID = reader["NationalIDNumber"].ToString();
                        employee.LoginID = reader["LoginID"].ToString();
                        employee.JobTitle = reader["JobTitle"].ToString();
                        employee.DateOfBirth = DateTime.Parse(reader["BirthDate"].ToString());
                        employee.EmployeeMaritalStatus = reader["MaritalStatus"].ToString() == "M" ? MaritalStatus.Married : MaritalStatus.Single;
                        employee.EmployeeSex = reader["Gender"].ToString() == "M" ? Sex.Male : Sex.Female;
                        employee.HireOnDate = DateTime.Parse(reader["HireDate"].ToString());

                        returnEmployees.Add(employee);
                    }
                }
                finally
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return returnEmployees;
        }
    }
}
