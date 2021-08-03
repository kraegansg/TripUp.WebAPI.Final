using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripUp.Models;
using TripUp.Services;

namespace TripUp.WebAPI.Final.Controllers
{

    [Authorize]
    public class TravelController : Controller
    {

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TravelService(userId);
            var model = service.GetTravels();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TravelCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateTravelService();

            if (service.CreateTravel(model))
            {
                TempData["SaveResult"] = "Travel created successfully.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Travel could not be created.");
            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateTravelService();
            var model = svc.GetTravelById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTravelService();
            var detail = service.GetTravelById(id);
            var model =
                new TravelEdit
                {
                    TravelId = detail.TravelId,
                    TravelName = detail.TravelName,
                    StartingLocation = detail.StartingLocation,
                    TravelBuddies = detail.TravelBuddies,
                    PitStops = detail.PitStops,
                    Destination = detail.Destination
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TravelEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TravelId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTravelService();

            if (service.UpdateTravel(model))
            {
                TempData["SaveResult"] = "Your Travel was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Travel could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateTravelService();
            var model = svc.GetTravelById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTravelService();
            service.DeleteTravel(id);
            TempData["SaveResult"] = "Your Travel was deleted.";
            return RedirectToAction("Index");
        }

        private TravelService CreateTravelService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TravelService(userId);
            return service;
        }
    }
}