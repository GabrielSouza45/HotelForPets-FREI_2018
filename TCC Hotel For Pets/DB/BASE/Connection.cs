using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.BASE
{
    class Connection
    {
        public MySqlConnection Create()
        {
            //string connectionstring = "server=104.214.59.125;database=Tcc;uid=nsf;password=nsf@2018;sslmode=none";
            //string connectionstring = "server=192.168.0.100;database=Tcc;uid=nsf;password=nsf@2018;sslmode=none";
            string connectionstring = "server=70.37.57.127;database=Tcc;uid=nsf;password=nsf@2018;sslmode=none";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();

            return connection;


        }

    }
}
