using System;
using System.Data.SqlClient;

namespace SqlConnectionStringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";
                builder.InitialCatalog = "master";
                builder.IntegratedSecurity = true;

                var cstring = builder.ConnectionString;
                Console.WriteLine(cstring);

                using (SqlConnection connection = new SqlConnection(cstring)) //using lets us close out without "close"
                {
                    connection.Open();
                    Console.WriteLine("Connection is Open");

                    string sqlQuery = "CREATE DATABASE Movie ";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done with command");
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
