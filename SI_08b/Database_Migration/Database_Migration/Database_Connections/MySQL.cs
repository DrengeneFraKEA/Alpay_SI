using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Migration
{
    public class MySQL
    {
        public MySqlConnection Db { get; set; }
        public bool UseLocalHost = true;
        public string DbName = "hms";

        public MySQL() 
        {
            this.Db = new MySqlConnection("Server=localhost;Database=hms;Uid=root;Pwd=1234;");
        }
    }
}
