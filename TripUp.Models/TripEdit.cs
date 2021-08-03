using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Models
{
    public class TripEdit
    {
        public string TripName { get; set; }
        public bool Favorite { get; set; }
        public int TravelId { get; set; }
        public int PackId { get; set; }
        public int ToDoListId { get; set; }
    }
}
