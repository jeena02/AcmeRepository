using AcmeWidgetApp.Models.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetApp.Models.Registration
{
    public class ParticipantInfo
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }

        [ForeignKey("ActivityId")]
        //public int ActivityRefId { get; set; }
        public Activity ActivityList { get; set; } = new Activity();

        [NotMapped]
        public int ActivityId { get; set; }
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Comments { get; set; }

    }
}
