using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SMSApp.Entities
{
    public class StudentMarks
    {
        [DisplayName("Student Name")]
        public int StudentId { get; set; }
        public int Professorid { get; set; }
        public int Rank { get; set; }
        public DateTime createdDate { get; set; }

        [Required]
        public string  Subject1 { get; set; }
        [Required]
        public int Marks1 { get; set; }
        [Required]
        public string  Grade1 { get; set; }


        [Required]
        public string Subject2 { get; set; }
        [Required]
        public int Marks2 { get; set; }
        [Required]
        public string  Grade2 { get; set; }


        [Required]
        public string Subject3 { get; set; }
        [Required]
        public int Marks3 { get; set; }
        [Required]
        public string  Grade3 { get; set; }

        public string Subject4 { get; set; }
        public int Marks4 { get; set; }
        public string  Grade4 { get; set; }

        public string Subject5 { get; set; }
        public int Marks5 { get; set; }
        public string  Grade5 { get; set; }

        public string Subject6 { get; set; }
        public int Marks6 { get; set; }
        public string  Grade6 { get; set; }

        public int TotalMarks { get; set; }
        public string FinalGrade { get; set; }
        public int Percentage { get; set; }
    }
}
