using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMSApp.Entities
{
    public class Announcement
    {
        public int id { get; set; }
        [DisplayName("Destination User")]
        [Required]
        public int DestinationId { get; set; }
        public int CreatedById { get; set; }

        [Required]
        public int AnnouncementType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime AnnounceDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
