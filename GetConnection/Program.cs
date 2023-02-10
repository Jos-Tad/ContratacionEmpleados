using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"source=192.168.20.62\SQL2019;initial catalog=bd_Pruebas;user id=UsrIGC;password=UsrIGC;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
            }
        }
    }
}
