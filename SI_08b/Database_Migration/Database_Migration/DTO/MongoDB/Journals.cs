using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Migration.DTO.MongoDB
{
    [BsonIgnoreExtraElements]
    public class Journals
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        [BsonElement("journalid")]
        public int JournalId { get; set; }
        [BsonElement("doctorid")]
        public int DoctorId { get; set; }
        [BsonElement("journalnote")]
        public string JournalNote { get; set; }
        [BsonElement("createdon")]
        public DateTime? CreatedOn { get; set; }
        [BsonElement("modifiedon")]
        public DateTime? ModifiedOn { get; set; }
        [BsonElement("cpr")]
        public string CPR { get; set; }
    }
}
