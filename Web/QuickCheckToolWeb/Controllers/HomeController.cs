﻿using QuickCheckToolWeb.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickCheckToolWeb.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult ReadServers()
        {
            return Json(Servers.GetInstance().ReadServers(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}