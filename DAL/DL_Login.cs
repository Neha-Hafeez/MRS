using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.DAL
{
    public class DL_Login
    {
        public int ValidateLogin(string username, string password)
        {
            int roleId = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["MRS_Connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand myCommand = new SqlCommand("ValidateUser", con))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@Username", username);
                        myCommand.Parameters.AddWithValue("@PasswordHash", password);

                        var result = myCommand.ExecuteScalar();

                        if (result != null)
                        {
                            roleId = Convert.ToInt32(result);
                            return roleId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while validating login.", ex);
                }
                finally
                {
                    con.Close();
                }
            }

            return roleId; // Login failed
        }
    }
}