using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Entities
{
   public  class EnrollSports
    {
        public int id { get; set; }        
        public int Studentid { get; set; }
        [DisplayName("Sports Type")]
        public int SportsId { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
    }
}
