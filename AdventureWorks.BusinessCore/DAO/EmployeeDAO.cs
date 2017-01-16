using AdventureWorks.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BusinessCore.DAO
{
    public class EmployeeDAO
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> returnEmployees = new List<Employee>();
            string conn = ConfigurationManager.ConnectionStrings["azureAdventureWorks"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(conn))
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
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return returnEmployees;
        }

        public Employee GetEmployee(int employeeID)
        {
            Employee employee = new Employee();
            string conn = ConfigurationManager.ConnectionStrings["azureAdventureWorks"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                SqlDataReader reader = null;

                try
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.usp_Employee_SelectSingle", sqlConnection);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // execute the command
                    reader = cmd.ExecuteReader();

                    // iterate through results, printing each to console
                    while (reader.Read())
                    {
                        employee.Id = Int32.Parse(reader["BusinessEntityID"].ToString());
                        employee.NationalID = reader["NationalIDNumber"].ToString();
                        employee.LoginID = reader["LoginID"].ToString();
                        employee.JobTitle = reader["JobTitle"].ToString();
                        employee.DateOfBirth = DateTime.Parse(reader["BirthDate"].ToString());
                        employee.EmployeeMaritalStatus = reader["MaritalStatus"].ToString() == "M" ? MaritalStatus.Married : MaritalStatus.Single;
                        employee.EmployeeSex = reader["Gender"].ToString() == "M" ? Sex.Male : Sex.Female;
                        employee.HireOnDate = DateTime.Parse(reader["HireDate"].ToString());
                    }
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return employee;
        }

        public void UpdateEmployee(Employee employeeToUpdate)
        {
            string conn = ConfigurationManager.ConnectionStrings["azureAdventureWorks"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.usp_Employee_Update", sqlConnection);
                    cmd.Parameters.AddWithValue("@businessEntityID", employeeToUpdate.Id);
                    cmd.Parameters.AddWithValue("@nationalIDNumber", employeeToUpdate.NationalID);
                    cmd.Parameters.AddWithValue("@loginID", employeeToUpdate.LoginID);
                    cmd.Parameters.AddWithValue("@jobTitle", employeeToUpdate.JobTitle);
                    cmd.Parameters.AddWithValue("@birthDate", employeeToUpdate.DateOfBirth);
                    cmd.Parameters.AddWithValue("@maritalStatus", employeeToUpdate.EmployeeMaritalStatus == MaritalStatus.Single ? 'S' : 'M');
                    cmd.Parameters.AddWithValue("@gender", employeeToUpdate.EmployeeSex == Sex.Female ? 'F' : 'M');
                    cmd.Parameters.AddWithValue("@hireDate", employeeToUpdate.HireOnDate);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                } catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
