using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Common
{
    public class Discussion
    {
        public Int64 id { get; set; }
        public int Student_id { get; set; }
        public string StudentName { get; set; }
        public int Professor_Id { get; set; }
        public string ProfessorName { get; set; }
        public string Discussion_topic { get; set; }
        public string Discussion_msg { get; set; }
        public string DiscussionAnswar { get; set; }
    }
}
