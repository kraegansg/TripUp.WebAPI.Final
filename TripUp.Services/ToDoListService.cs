using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripUp.Data;
using TripUp.Models;
using TripUp.WebAPI.Final.Models;

namespace TripUp.Services
{
    public class ToDoListService
    {
        private readonly Guid _userId;

        public ToDoListService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateToDoList(ToDoListCreate model)
        {
            var entity =
                new ToDoList()
                {
                    OwnerId = _userId,
                    PetCare = model.PetCare,
                    ChildCare = model.ChildCare,
                    HouseCare = model.HouseCare,
                    ToDoMisc = model.ToDoMisc,
                    ToDoListName = model.ToDoListName

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ToDoLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ToDoListItem> GetToDoLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ToDoLists
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new ToDoListItem
                            {
                                ToDoListId = e.ToDoListId,
                                ToDoListName = e.ToDoListName,
                                ToDoMisc = e.ToDoMisc,
                                PetCare = e.PetCare,
                                ChildCare = e.ChildCare,
                                HouseCare = e.HouseCare,

                            }
                                );
                return query.ToArray();
            }
        }

        public ToDoListDetail GetToDoListById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ToDoLists
                    .Single(e => e.ToDoListId == id && e.OwnerId == _userId);
                return
                    new ToDoListDetail
                    {
                        ToDoListId = entity.ToDoListId,
                        ToDoMisc = entity.ToDoMisc,
                        PetCare = entity.PetCare,
                        ChildCare = entity.ChildCare,
                        HouseCare = entity.HouseCare,
                        ToDoListName = entity.ToDoListName,
                    };
            }
        }


        public bool UpdateToDoList(ToDoListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ToDoLists
                        .Single(e => e.ToDoListId == model.ToDoListId && e.OwnerId == _userId);

                entity.ToDoListName = model.ToDoListName;
                entity.ToDoMisc = model.ToDoMisc;
                entity.PetCare = model.PetCare;
                entity.ChildCare = model.ChildCare;
                entity.HouseCare = model.HouseCare;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteToDoList(int toDoListId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ToDoLists
                        .Single(e => e.ToDoListId == toDoListId && e.OwnerId == _userId);
                ctx.ToDoLists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

