using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Entities
{
   public class Assignment
    {
        public int assignment_Id { get; set; }
        public int Userid { get; set; }
        public string SchoolName { get; set; }
        public string Location { get; set; }
        public int ProfessorId { get; set; }
        public int Course { get; set; }
        public int StudentId { get; set; }
        public int Year { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string Topic { get; set; }
        public string AssignmentWork { get; set; }
        public DateTime createdDatetime { get; set; }
    }
}
