using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Data
{
    public class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }
        public string PetCare { get; set; }
        public string ChildCare { get; set; }
        public string HouseCare { get; set; }
        public string ToDoMisc { get; set; }
        public Guid OwnerId { get; set; }
        public string ToDoListName { get; set; }
    }
}
