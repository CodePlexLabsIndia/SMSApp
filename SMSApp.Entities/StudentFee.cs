using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Entities
{
    public class StudentFee
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public string SchoolName { get; set; }

        public string LocationName { get; set; }

        public int ProfessorID { get; set; }

        public int CourseID { get; set; }

        public string AdmissionNumber { get; set; }

        public string RollNumber { get; set; }

        public string FeeReceiptNumber { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
