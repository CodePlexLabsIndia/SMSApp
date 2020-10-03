namespace SMSApp.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class UserInfoEntity
    {
        public int MembershipID { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        [DisplayName("DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]

        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Date Of Joining")]
        [DataType(DataType.Date)]
        public DateTime? DateOfJoining { get; set; }

        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public int RoleID { get; set; }

        public byte[] pic { get; set; }

        public int ProffesorID { get; set; }

        public string ProfessorName { get; set; }

        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public bool IsActive { get; set; }

        public List<Professor> ProfessorList { get; set; }

        public string SSCMarks { get; set; }

        public string SSCPercentage { get; set; }

        public string YearofPassing { get; set; }

        public string IntermediateMarks { get; set; }

        public string IntermediatePercentage { get; set; }

        public string FeesPerYear { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string PresentAddress { get; set; }

        public string PermanentAddress { get; set; }

        public string ParentPhone { get; set; }

        public string ParentEmail { get; set; }

        public int SportID { get; set; }

        public string SportDescription { get; set; }
    }

    public class Professor
    {
        public int ProffesorID { get; set; }

        public string ProffesorName { get; set; }
    }
}
