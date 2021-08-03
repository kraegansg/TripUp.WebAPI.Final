using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Models
{
    public class TripDetail
    {
        public int TripId { get; set; }
        public string TripName { get; set; }
        public bool Favorite { get; set; }
        public string Destination { get; set; }
        public string StartingLocation { get; set; }
        public string TravelBuddies { get; set; }
        public string PitStops { get; set; }
        public string Clothes { get; set; }
        public string BathItems { get; set; }
        public string Essentials { get; set; }
        public string Other { get; set; }
        public string PetCare { get; set; }
        public string ChildCare { get; set; }
        public string HouseCare { get; set; }
        public string ToDoMisc { get; set; }

    }
}
