using SMSApp.DataAccess;
using SMSApp.Common;
using SMSApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Controllers
{
   public  class StudentManager
    {
        public StudentMarks ViewMarks(int StudentId)
        {
            return new StudentContext().ViewMarks(StudentId);
        }

        public int SaveEducationInfo(UserInfoEntity entity)
        {
            return new StudentContext().SaveEducationDetails(entity);
        }

        public int SaveParentsInfo(UserInfoEntity entity)
        {
            return new StudentContext().SaveParentDetails(entity);
        }

        internal int SaveEnrollCourse(EnrollCourse entity)
        {
            return new StudentContext().SaveEnrollCourse(entity);
        }

        internal int SaveEnrollSports(EnrollSports entity)
        {
            return new StudentContext().SaveEnrollSports(entity);
        }

        internal int UpdateDiscussion(Discussion entity)
        {
            return new StudentContext().UpdateDiscussion(entity);
        }

        internal int InsertStudentFee(StudentFee entity)
        {
            return new StudentContext().SaveStudentFee(entity);
        }
    }
}
