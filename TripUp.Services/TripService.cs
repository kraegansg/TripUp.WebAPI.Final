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
    public class TripService
    {
        private readonly Guid _userId;

        public TripService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTrip(TripCreate model)
        {
            var entity =
                new Trip()
                {
                    OwnerId = _userId,
                    TripName = model.TripName,
                    Favorite = model.Favorite,
                    TravelId = model.TravelId,
                    PackId = model.PackId,
                    ToDoListId = model.ToDoListId,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trips.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TripListItem> GetTrips()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Trips
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new TripListItem
                            {
                                TripId = e.TripId,
                                TripName = e.TripName,
                                Favorite = e.Favorite,
                                Destination = e.Travel.Destination,
                                StartingLocation = e.Travel.StartingLocation,
                                TravelBuddies = e.Travel.TravelBuddies,
                                PitStops = e.Travel.PitStops,
                                Clothes = e.Pack.Clothes,
                                BathItems = e.Pack.BathItems,
                                Essentials = e.Pack.Essentials,
                                Other = e.Pack.Other,
                                PetCare = e.ToDoList.PetCare,
                                ChildCare = e.ToDoList.ChildCare,
                                HouseCare = e.ToDoList.HouseCare,
                                ToDoMisc = e.ToDoList.ToDoMisc

                            }
                                );
                return query.ToArray();
            }
        }

        public TripDetail GetTripById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .Single(e => e.TripId == id && e.OwnerId == _userId);
                return
                    new TripDetail
                    {

                        TripId = entity.TripId,
                        TripName = entity.TripName,
                        Favorite = entity.Favorite,
                        Destination = entity.Travel.Destination,
                        StartingLocation = entity.Travel.StartingLocation,
                        TravelBuddies = entity.Travel.TravelBuddies,
                        PitStops = entity.Travel.PitStops,
                        Clothes = entity.Pack.Clothes,
                        BathItems = entity.Pack.BathItems,
                        Essentials = entity.Pack.Essentials,
                        Other = entity.Pack.Other,
                        PetCare = entity.ToDoList.PetCare,
                        ChildCare = entity.ToDoList.ChildCare,
                        HouseCare = entity.ToDoList.HouseCare,
                        ToDoMisc = entity.ToDoList.ToDoMisc

                    };
            }
        }


        public bool UpdateTrip(TripEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trips
                        .Single(e => e.TripId == model.TripId && e.OwnerId == _userId);

                entity.TripName = model.TripName;
                entity.Favorite = model.Favorite;
                entity.TravelId = model.TravelId;
                entity.PackId = model.PackId;
                entity.ToDoListId = model.ToDoListId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTrip(int tripId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trips
                        .Single(e => e.TripId == tripId && e.OwnerId == _userId);
                ctx.Trips.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
