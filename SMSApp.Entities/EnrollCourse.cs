using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Entities
{
   public class EnrollCourse
    {
        public int Enroll_Id { get; set; }
        public int Studentid { get; set; }
        [DisplayName("Course Name")]
        public int CourseId { get; set; }
        [DisplayName("Course Type")]
        public int CourseType { get; set; }
        [DisplayName("School Name")]
        public string SchoolName { get; set; }
        [DisplayName("Location")]
        public string LocationName { get; set; }
        [DisplayName("Professor")]
        public int Professorid { get; set; }
        public DateTime createdDateTime { get; set; }
    }
}
