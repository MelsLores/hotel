using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Clases
{
    public class Conexion
    {
        static void main() {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "LAPTOP-HA8MFSBO",
                    UserID = "sa",
                    Password = "1234",
                    InitialCatalog = "hotel2"
                };
            }
            catch (Exception)
            {

            }
        }
    }
}
