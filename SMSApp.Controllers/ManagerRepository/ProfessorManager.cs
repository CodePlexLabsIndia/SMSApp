using SMSApp.Common;
using SMSApp.DataAccess;
using SMSApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Controllers.ManagerRepository
{
 public    class ProfessorManager
    {
        public UserInfoEntity UpdateProfessor(UserInfoEntity entity)
        {
            return new ProfessorContext().UpdateProfessor(entity);
        }
        public void AddMarks(StudentMarks entity)
        {
            new ProfessorContext().AddMarks(entity);
        }
        public void AddAssignment(Assignment  entity)
        {
            new ProfessorContext().AddAssignment(entity);
        }

        public List<UserInfoEntity> GetStudents(int roleid)
        {
            return new ProfessorContext().GetStudents(roleid);
        }
        public Discussion AddProfDiscussion(Discussion entity)
        {
            return new ProfessorContext().AddProfDiscussion(entity);
        }
        public List<UserInfoEntity> GetDDLStudents(int roleid)
        {
            return new ProfessorContext().GetDDLStudents(roleid);
        }

        internal void AddAnnouncement(Announcement obj)
        {
             new ProfessorContext().AddAnnouncement(obj);
        }

        public List<UserInfoEntity> GetStudentsByProf(int roleID,int profID)
        {
            return new ProfessorContext().GetStudentByProf(roleID, profID);
        }

        public List<Discussion> GetDiscussion(int userID, string Type)
        {
            return new ProfessorContext().GetDiscussion(userID, Type);
        }
    }
}
