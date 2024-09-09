using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Models
{
    public class UserRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["UserAuthDBContext"].ConnectionString;

        public User ValidateUser(string username, string passwordHash)
        {
            User user = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ValidateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
 
                    SqlParameter roleIdParam = new SqlParameter("@RoleId", SqlDbType.Int);
                    roleIdParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(roleIdParam);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (roleIdParam.Value != DBNull.Value)
                    {
                        user = new User
                        {
                            Username = username,
                            RoleId = Convert.ToInt32(roleIdParam.Value)
                        };
                    }
                }
            }
            return user;
        }
    }
}