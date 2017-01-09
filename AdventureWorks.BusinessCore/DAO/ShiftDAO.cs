using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureWorks.Model;
using System.Data;

namespace AdventureWorks.BusinessCore.DAO
{
    public class ShiftDAO
    {
        private const string CONNECTION_STRING = @"Server=tcp:cfq4uoqy8a.database.windows.net,1433;Initial Catalog=AdventureWorks2012;Persist Security Info=False;User ID=mjsonAdmin;Password=Solstice123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<Shift> GetAllShifts()
        {
            List<Shift> returnShifts = new List<Shift>();
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                SqlDataReader reader = null;

                try
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.usp_Shift_SelectAll", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // execute the command
                    reader = cmd.ExecuteReader();

                    // iterate through results, printing each to console
                    while (reader.Read())
                    {
                        Shift shift = new Shift();
                        shift.Id = Int32.Parse(reader["ShiftID"].ToString());
                        shift.Name = reader["Name"].ToString();
                        shift.StartTime = new Time(DateTime.Parse(reader["StartTime"].ToString()));
                        shift.EndTime = new Time(DateTime.Parse(reader["EndTime"].ToString()));

                        returnShifts.Add(shift);
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

            return returnShifts;
        }
    }
}
