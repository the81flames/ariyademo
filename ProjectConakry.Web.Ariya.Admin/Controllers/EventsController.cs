﻿using ProjectConakry.BusinessServices;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Admin.Controllers
{
    public class EventsController : Controller
    {
       private readonly EventsManagementService _eventsService;
       public EventsController(EventsManagementService eventsService)
        {
            _eventsService = eventsService;
        }

        [ConakryAdminAuthorize]
        public ActionResult Index()
        {
            var allEvents = _eventsService.GetAll();
            return View(allEvents);
        }

        [HttpPost]
        public ActionResult Add(Events eventItem)
        {
            _eventsService.Add(eventItem);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var eventItem = _eventsService.GetById(id);
            eventItem.IdString = id.ToString();
            return View("EditEvent", eventItem);
        }

        [HttpPost]
        public ActionResult Edit(Events eventItem)
        {
            _eventsService.Update(eventItem);
            return RedirectToAction("Index");
        }

    }
}
