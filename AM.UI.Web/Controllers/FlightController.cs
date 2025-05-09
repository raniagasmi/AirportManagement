using System.Numerics;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {
        IFlightService fs;

        IPlaneService ps;

        public FlightController(IFlightService fs, IPlaneService ps)
        {
            this.fs = fs;
            this.ps = ps;
        }

        public ActionResult Sort()

        {

            return View("Index", fs.SortFlights());

        }


        // GET: FlightController

        public ActionResult Index(DateTime? dateDepart)

        {

            if (dateDepart == null)

                return View(fs.GetAll().ToList());

            else

                return View(fs.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());

        }

        // GET: FlightController/Details/5
        public IActionResult Details(int id)
        {
            var flight = fs.GetById(id);
            if (flight == null)
                return NotFound();

            return View(flight); // renvoie vers la vue Details.cshtml

        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.planeFK = new SelectList(ps.GetAll(), "PlaneId", "ManufactureDate");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create(Flight flight, IFormFile PilotImage)

        {


            try

            {

                if (PilotImage != null)

                {

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", PilotImage.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }


                    flight.Pilot = PilotImage.FileName;
                }
                fs.Add(flight);

                fs.Commit();

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View();

            }

        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var flight = fs.GetById(id);

            // 👇 Ce code remplit ViewBag.planeFK avec la liste des avions
            ViewBag.planeFK = new SelectList(ps.GetAll(), "PlaneId", "PlaneType", flight.PlaneFk);

            return View(flight);
        }


        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight)
        {
            try
            {
                fs.Update(flight);   // Assure-toi que Update existe dans IFlightService
                fs.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(flight);
            }
        }


        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            var flight = fs.GetById(id);
            return View(flight); // On affiche les détails à supprimer
        }

        // POST: FlightController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                fs.Delete(fs.GetById(id));
                fs.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult FlightDetails(int id)
        {
            var flight = fs.GetById(id);
            return PartialView("_FlightDetails", flight);
        }

      






    }
}
