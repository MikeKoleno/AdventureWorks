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
        public List<Shift> GetAllShifts()
        {
            List<Shift> returnShifts = new List<Shift>();
            string conn = ConfigurationManager.ConnectionStrings["azureAdventureWorks"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(conn))
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
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }

            return returnShifts;
        }

        public Shift GetShift(int shiftID)
        {
            Shift shift = new Shift();
            string conn = ConfigurationManager.ConnectionStrings["azureAdventureWorks"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                SqlDataReader reader = null;

                try
                {
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand("dbo.usp_Shift_SelectSingle", sqlConnection);
                    cmd.Parameters.AddWithValue("@shiftID", shiftID);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // execute the command
                    reader = cmd.ExecuteReader();

                    // iterate through results, printing each to console
                    while (reader.Read())
                    {
                        shift.Id = Int32.Parse(reader["ShiftID"].ToString());
                        shift.Name = reader["Name"].ToString();
                        shift.StartTime = new Time(DateTime.Parse(reader["StartTime"].ToString()));
                        shift.EndTime = new Time(DateTime.Parse(reader["EndTime"].ToString()));
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

            return shift;
        }
    }
}
