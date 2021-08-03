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
    public class TravelService
    {
        private readonly Guid _userId;

        public TravelService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTravel(TravelCreate model)
        {
            var entity =
                new Travel()
                {
                    OwnerId = _userId,
                    Destination = model.Destination,
                    StartingLocation = model.StartingLocation,
                    TravelBuddies = model.TravelBuddies,
                    PitStops = model.PitStops,
                    TravelName = model.TravelName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Travels.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TravelListItem> GetTravels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Travels
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new TravelListItem
                            {
                                TravelId = e.TravelId,
                                Destination = e.Destination,
                                StartingLocation = e.StartingLocation,
                                TravelBuddies = e.TravelBuddies,
                                PitStops = e.PitStops,
                                TravelName = e.TravelName
                            }
                                );
                return query.ToArray();
            }
        }

        public TravelDetail GetTravelById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Travels
                    .Single(e => e.TravelId == id && e.OwnerId == _userId);
                return
                    new TravelDetail
                    {
                        TravelId = entity.TravelId,
                        Destination = entity.Destination,
                        StartingLocation = entity.StartingLocation,
                        TravelBuddies = entity.TravelBuddies,
                        PitStops = entity.PitStops,
                        TravelName = entity.TravelName
                    };
            }
        }


        public bool UpdateTravel(TravelEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Travels
                        .Single(e => e.TravelId == model.TravelId && e.OwnerId == _userId);

                entity.TravelName = model.TravelName;
                entity.Destination = model.Destination;
                entity.StartingLocation = model.StartingLocation;
                entity.TravelBuddies = model.TravelBuddies;
                entity.PitStops = model.PitStops;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTravel(int travelId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Travels
                        .Single(e => e.TravelId == travelId && e.OwnerId == _userId);
                ctx.Travels.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}