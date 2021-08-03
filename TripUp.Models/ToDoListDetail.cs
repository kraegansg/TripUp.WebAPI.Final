using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripUp.Models
{
    public class ToDoListDetail
    {
        public int ToDoListId { get; set; }
        public string PetCare { get; set; }
        public string ChildCare { get; set; }
        public string HouseCare { get; set; }
        public string ToDoMisc { get; set; }
        public string ToDoListName { get; set; }
    }
}
