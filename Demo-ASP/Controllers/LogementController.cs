using Demo_ASP.Handlers;
using Demo_ASP.Models.ClientViewModels;
using Demo_ASP.Models.LogementViewModels;
using Demo_BLL.Entities;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Demo_ASP.Controllers
{
    public class LogementController : Controller
    {
        private readonly ILogementRepository<Logement, int> _service;
        private readonly IClientRepository<Client, int> _serviceClient;
        private readonly IReservationRepository<Reservation, int> _serviceReservation;

        private readonly SessionManager _sessionManager;


        public LogementController(IReservationRepository<Reservation, int> serviceReservation ,IClientRepository<Client, int> serviceClient, ILogementRepository<Logement, int> service, SessionManager sessionManager)
        {
            _service = service;
            _serviceClient = serviceClient;
            _serviceReservation = serviceReservation;
            _sessionManager = sessionManager;
        }

        // GET: LogementController
        public ActionResult Index()
        {
            IEnumerable<LogementListItem> model = _service.Get().Select(e => e.ToListItem());

            return View(model);
        }

        //GET: LogementController/Details/5
        public ActionResult Details(int id)
        {
            LogementDetails model = _service.Get(id).ToDetails();
            if (model is null)
            {
                TempData["Error"] = "Logement inexistant...";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult MyLogement()
        {
            IEnumerable<LogementListItem> model = _service.GetMyLogement(_sessionManager.CurrentUser.IdUser).Select(e => e.ToListItem());
           
            return View(model);
        }

        // GET: LogementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogementCreateForm form)
        {
            if (!ModelState.IsValid) return View(form);
            form.Client_id = _sessionManager.CurrentUser.IdUser;
            form.date_add = DateTime.Now;
            int id = _service.Insert(form.ToBLL());
            return RedirectToAction("Details", new { id = id });
        }

        // GET: LogementController/Create
        public ActionResult SearchMonth()
        {
            var search = new LogementSearch();
            search.date = DateTime.Now;
            search.logements = new List<LogementListItem>();
            return View(search);
        }
        // POST: LogementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchMonth(LogementSearch form)
        {
            IEnumerable<LogementListItem> model = _service.GetLogementMonth(form.date).Select(e => e.ToListItem());

            var search = new LogementSearch();
            search.logements = model;

            return View(search);
        }

        // GET: LogementController/Create
        public ActionResult SearchTwoDate()
        {
            var search = new LogementSearch();
            search.date_deb = DateTime.Now;
            search.date_fin = DateTime.Now;

            search.logements = new List<LogementListItem>();
            return View(search);
        }
        // POST: LogementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  SearchTwoDate(LogementSearch form)
        {
            IEnumerable<LogementListItem> model = _service.GetLogementTwoDate(form.date_deb,form.date_fin).Select(e => e.ToListItem());

            var search = new LogementSearch();
            search.logements = model;

            return View(search);
        }

        // GET: LogementController/Edit/5
        public ActionResult Edit(int id)
        {
            var logement = _service.Get(id).ToEdit();
           
            return View(logement);

        }

        // POST: LogementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LogementEditForm form)
        {
            if (!ModelState.IsValid) return View(form);
            if (!_service.Update(id, form.ToBLL()))
            {
                ViewBag.Error = "Erreur lors de la mise à jour... Réessayez";
                return View(form);
            }
            return RedirectToAction("Details", new { id = id });
        }

        // GET: LogementController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    LogementDelete model = _service.Get(id).ToDelete();
        //    if (model is null)
        //    {
        //        TempData["Error"] = "Logement inexistant...";
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}

        public ActionResult Delete(int id)
        {
            var logement = _serviceReservation.GetReservationLogement(id);
            if(logement.Count() != 0) return RedirectToAction("MyLogement");

            bool e = _service.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: LogementController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, LogementDelete form)
        //{
        //    if (!_service.Delete(id))
        //    {
        //        TempData["Error"] = "Erreur de suppression...";
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
