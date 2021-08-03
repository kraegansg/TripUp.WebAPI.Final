using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Data
{
    public class Travel
    {
        [Key]
        public int TravelId { get; set; }
        public Guid OwnerId { get; set; }
        public string Destination { get; set; }
        public string StartingLocation { get; set; }
        public string TravelBuddies { get; set; }
        public string PitStops { get; set; }
        public string TravelName { get; set; }
    }
}
