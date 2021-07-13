using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidgetApp.ClientApp.Models.Registration
{
    public class ParticipantInfo
    {
   
    public int Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }

   
    public string Email { get; set; }

    public int ActivityId { get; set; }
    public Activity ActivityList { get; set; } = new Activity();

    
    public string PhoneNumber { get; set; }
   
    public string Comments { get; set; }
  }
}
