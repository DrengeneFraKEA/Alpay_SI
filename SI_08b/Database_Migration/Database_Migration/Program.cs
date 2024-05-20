using Database_Migration.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Database_Migration
{
    // Example of one table - one can ofcourse also iterate through every table in db
    public class Program
    {
        static void Main(string[] args)
        {
            // Establish connection to databases
            MySQL mysql = new MySQL();
            MongoDB mongodb = new MongoDB();

            List<Journals> journals = new List<Journals>();

            mysql.Db.Open();

            var command = new MySqlCommand($"SELECT * FROM journal;", mysql.Db);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Journals journal = new Journals()
                {
                    Id = reader.GetInt32("id"),
                    DoctorId = reader.GetInt32("doctor_id"),
                    Note = reader.GetString("journalnotes"),
                    CreatedOn = reader.GetDateTime("created_on"),
                    ModifiedOn = reader.GetDateTime("modified_on"),
                    CPR = reader.GetString("cpr")
                };

                journals.Add(journal);
            }

            mysql.Db.Close();


            // Iterate what was found and insert into MongoDB
            foreach (var element in journals) 
            {
                var database = mongodb.MongoClient.GetDatabase("HMS"); // mongodb database name
                var journalCollection = database.GetCollection<DTO.MongoDB.Journals>("si_08b"); // mongodb collection name

                DTO.MongoDB.Journals journal = new DTO.MongoDB.Journals()
                {
                    JournalId = element.Id,
                    DoctorId = element.DoctorId,
                    JournalNote = element.Note,
                    CreatedOn = element.CreatedOn,
                    ModifiedOn = element.ModifiedOn,
                    CPR = element.CPR
                };

                journalCollection.InsertOne(journal);
            }
        }
    }
}
