using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : BaseClass, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                                                   ([Id]
                                                   ,[Login]
                                                   ,[Current_Salary]
                                                   ,[Current_Rate]
                                                   ,[Currency]
                                                   ,[Country_Code]
                                                   ,[State_Province_Code]
                                                   ,[Street_Address]
                                                   ,[City_Town]
                                                   ,[Zip_Postal_Code])
                                             VALUES
                                                   (@Id
                                                   ,@Login
                                                   ,@Current_Salary
                                                   ,@Current_Rate
                                                   ,@Currency
                                                   ,@Country_Code
                                                   ,@State_Province_Code
                                                   ,@Street_Address
                                                   ,@City_Town
                                                   ,@Zip_Postal_Code)";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town",poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = @"SELECT [Id]
                                          ,[Login]
                                          ,[Current_Salary]
                                          ,[Current_Rate]
                                          ,[Currency]
                                          ,[Country_Code]
                                          ,[State_Province_Code]
                                          ,[Street_Address]
                                          ,[City_Town]
                                          ,[Zip_Postal_Code]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Applicant_Profiles]";

                int counter = 0;
                ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[500];

                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco();

                    poco.Id = rdr.GetGuid(0);
                    poco.Login = rdr.GetGuid(1);
                    if(rdr.IsDBNull(2))
                    {
                        poco.CurrentSalary = 0;
                    }
                    else
                    {
                        poco.CurrentSalary = rdr.GetDecimal(2);
                    }
                   
                    if(rdr.IsDBNull(3))
                    {
                        poco.CurrentRate = 0;
                    }
                    else
                    {
                        poco.CurrentRate = rdr.GetDecimal(3);
                    }
                    
                    if(rdr.IsDBNull(4))
                    {
                        poco.Currency = "";
                    }
                    else
                    {
                        poco.Currency = rdr.GetString(4);
                    }

                    if (rdr.IsDBNull(5))
                    {
                        poco.Country = "";
                    }
                    else
                    {
                        poco.Country = rdr.GetString(5);
                    }

                    if (rdr.IsDBNull(6))
                    {
                        poco.Province = "";
                    }
                    else
                    {
                        poco.Province = rdr.GetString(6);
                    }
                    
                    if(rdr.IsDBNull(7))
                    {
                        poco.Street = "";
                    }
                    else
                    {
                        poco.Street = rdr.GetString(7);
                    }
                    

                    if(rdr.IsDBNull(8))
                    {
                        poco.City = "";
                    }
                    else
                    {
                        poco.City = rdr.GetString(8);
                    }
                    
                    if(rdr.IsDBNull(9))
                    {
                        poco.PostalCode = "";
                    }
                    else
                    {
                        poco.PostalCode = rdr.GetString(9);
                    }
                   
                    poco.TimeStamp = (byte[])rdr[10];

                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();

                return pocos.Where(a => a != null).ToList();
            }
        }

        public IList<ApplicantProfilePoco> GetList(Func<ApplicantProfilePoco, bool> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Func<ApplicantProfilePoco, bool> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Profiles]
                                        WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Profiles]
                                        SET  [Login] = @Login
                                            ,[Current_Salary] = @Current_Salary
                                            ,[Current_Rate] = @Current_Rate
                                            ,[Currency] = @Currency
                                            ,[Country_Code] = @Country_Code
                                            ,[State_Province_Code] = @State_Province_Code
                                            ,[Street_Address] = @Street_Address
                                            ,[City_Town] = @City_Town
                                            ,[Zip_Postal_Code] = @Zip_Postal_Code
                                        WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town", poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
