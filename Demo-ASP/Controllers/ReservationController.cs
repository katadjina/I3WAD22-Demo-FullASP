using Demo_ASP.Handlers;
using Demo_ASP.Models.ClientViewModels;
using Demo_ASP.Models.ReservationViewModels;
using Demo_ASP.Models.LogementViewModels;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository<Reservation, int> _service;
        private readonly IClientRepository<Client, int> _serviceClient;
        private readonly ILogementRepository<Logement, int> _serviceLogement;
        private readonly SessionManager _sessionManager;


        public ReservationController(IReservationRepository<Reservation, int> service,IClientRepository<Client, int> serviceClient, ILogementRepository<Logement, int> serviceLogement, SessionManager sessionManager)
        {
            _service = service;
            _serviceClient = serviceClient;
            _serviceLogement = serviceLogement;
            _sessionManager = sessionManager;
        }

        // GET: ReservationController
        //public ActionResult Index()
        //{
        //    IEnumerable<ReservationListItem> model = _service.Get().Select(e => e.ToListItem());

        //    return View(model);
        //}

        //GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {


            ReservationDetails model = _service.Get(id).ToDetails();
            if (model is null)
            {
                TempData["Error"] = "Reservation inexistant...";
                return RedirectToAction("Index");
            }
            LogementDetails logement = _serviceLogement.Get(model.Logement_id).ToDetails();
            model.Logement_id = id;
            model.logement = logement;
            return View(model);
        }

        //public ActionResult MyReservation()
        //{
        //    IEnumerable<ReservationListItem> model = _service.GetMyReservation(_sessionManager.CurrentUser.IdUser).Select(e => e.ToListItem());

        //    return View(model);
        //}

        // GET: ReservationController/Create
        public ActionResult Create(int id)
        {
            LogementDetails model = _serviceLogement.Get(id).ToDetails();
            var form = new ReservationCreateForm();
            form.Logement_id = id;
            form.logement = model;

            return View(form);
        }

        public ActionResult MyReservation()
        {
            IEnumerable<ReservationListItem> model = _service.GetMyReservation(_sessionManager.CurrentUser.IdUser).Select(e => e.ToListItem());

            return View(model);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationCreateForm form)
        {
            if (!ModelState.IsValid) 
                return View(form);
            form.Client_id = _sessionManager.CurrentUser.IdUser;
            form.Logement_id = form.Logement_id;
            int id = _service.Insert(form.ToBLL());
            return RedirectToAction("Details", new { id = id });
        }

        //GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            var Reservation = _service.Get(id).ToEdit();
            LogementDetails model = _serviceLogement.Get(Reservation.Logement_id).ToDetails();

            Reservation.logement = model;
            return View(Reservation);

        }

        //POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReservationEditForm form)
        {
            if (!ModelState.IsValid) return View(form);
            if (!_service.Update(id, form.ToBLL()))
            {
                ViewBag.Error = "Erreur lors de la mise à jour... Réessayez";
                return View(form);
            }
            return RedirectToAction("Details", new { id = id });
        }

        // GET: ReservationController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    ReservationDelete model = _service.Get(id).ToDelete();
        //    if (model is null)
        //    {
        //        TempData["Error"] = "Reservation inexistant...";
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        public ActionResult Delete(int id)
        {
            bool e = _service.Delete(id);
            return RedirectToAction("MyReservation");
        }

        // POST: ReservationController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, ReservationDelete form)
        //{
        //    if (!_service.Delete(id))
        //    {
        //        TempData["Error"] = "Erreur de suppression...";
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
