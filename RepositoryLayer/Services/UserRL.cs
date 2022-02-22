using commomlayer.models;
using CommomLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private SqlConnection sqlConnection;

        public UserRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
       


        public bool Register(RegisterModel register)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStoreDB"));

            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("sp_AddUsers", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@FullName", register.FullName);
                    sqlCommand.Parameters.AddWithValue("@Email", register.Email);
                    sqlCommand.Parameters.AddWithValue("@PhoneNo", register.PhoneNo);
                    sqlCommand.Parameters.AddWithValue("@Password", register.Password);

                    int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public string Login(string emailId, string password)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStoreDB"));
            try
            {
                using (sqlConnection)
                {
                    RegisterModel model = new RegisterModel();
                   
                    SqlCommand command = new SqlCommand("sp_Login", sqlConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", emailId);
                    command.Parameters.AddWithValue("@Password", password);
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Email = Convert.ToString(reader["Email"] == DBNull.Value ? default : reader["Email"]);
                            model.Password = Convert.ToString(reader["Password"] == DBNull.Value ? default : reader["Password"]);
                        }
                        string token = GenerateToken(emailId);
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public string GenerateToken(string Email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim("Email", Email),
            
            };
            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"], Configuration["Jwt:Issuer"],
                  claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ForgetPassword(string EmailId)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStoreDB"));
            try
            {
                using (sqlConnection)
                {
                    RegisterModel model = new RegisterModel();
                    SqlCommand command = new SqlCommand("sp_ForgetPassword", sqlConnection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", EmailId);

                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Email = Convert.ToString(reader["Email"] == DBNull.Value ? default : reader["Email"]);
                        }
                        string token = GenerateToken(EmailId);
                        new msmqoperations().Sender(token);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool ResetPassword(ResetPassword newPassword, string EmailId)
        {
            try
            {
                sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("BookStoreDB"));
                using (this.sqlConnection)
                {
                    RegisterModel model = new RegisterModel();
                    SqlCommand command = new SqlCommand("sp_ResetPassword", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", EmailId);
                    command.Parameters.AddWithValue("@Password", newPassword.ConfirmPassword);
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Email = Convert.ToString(reader["Email"] == DBNull.Value ? default : reader["Email"]);
                            model.Password = Convert.ToString(reader["Password"] == DBNull.Value ? default : reader["Password"]);

                        }
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}
