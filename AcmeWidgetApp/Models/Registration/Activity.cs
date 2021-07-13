using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetApp.Models.Registration
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ActivityName { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }
    }
}
