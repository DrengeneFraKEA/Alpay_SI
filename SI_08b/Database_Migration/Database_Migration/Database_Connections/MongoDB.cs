using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Migration
{
    public class MongoDB
    {
        public string ConnectionString { get; set; }
        public MongoClientSettings Settings { get; set; }

        public MongoClient MongoClient { get; set; }

        public MongoDB() 
        {
            this.ConnectionString = "mongodb+srv://hms_admin:vGaQGWA85GqRofPf@hms.eigi1od.mongodb.net/?retryWrites=true&w=majority";
            this.Settings = MongoClientSettings.FromConnectionString(ConnectionString);
            this.Settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            this.MongoClient = new MongoClient(ConnectionString);
        }
    }
}
