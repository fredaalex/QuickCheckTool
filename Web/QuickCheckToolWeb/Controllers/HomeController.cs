using Newtonsoft.Json;
using QuickCheckToolWeb.Lib;
using QuickCheckToolWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult Create()
        {
            var server = new NewServerModel();
            server.HDPercentualThreshold = 90;
            server.MemoryPercentualThreshold = 80;
            server.ProcessPercentualThreshold = 95;
            return View(server);
        }
        [HttpPost]
        public ActionResult Create(NewServerModel newServer)
        {
            List<NewServerModel> servers = null;
            if(System.IO.File.Exists(@"C:\Users\Freda\Desktop\servers.json"))
            {
                servers = JsonConvert.DeserializeObject<List<NewServerModel>>(System.IO.File.ReadAllText(@"C:\Users\Freda\Desktop\servers.json"));
            }
            else
            {
                servers = new List<NewServerModel>();
            }

            servers.Add(newServer);

            System.IO.File.WriteAllText(@"C:\Users\Freda\Desktop\servers.json", JsonConvert.SerializeObject(servers));

            return Redirect("/");
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}