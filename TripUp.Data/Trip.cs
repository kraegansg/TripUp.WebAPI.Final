using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Data
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public string TripName { get; set; }
        public bool Favorite { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Travel))]
        public int? TravelId { get; set; }
        public virtual Travel Travel { get; set; }

        [ForeignKey(nameof(Pack))]
        public int PackId { get; set; }
        public virtual Pack Pack { get; set; }

        [ForeignKey(nameof(ToDoList))]
        public int ToDoListId { get; set; }
        public virtual ToDoList ToDoList { get; set; }
    }
}
