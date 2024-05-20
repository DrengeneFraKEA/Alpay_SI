using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Migration.DTO
{
    public class Journals
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CPR { get; set; }
    }
}
