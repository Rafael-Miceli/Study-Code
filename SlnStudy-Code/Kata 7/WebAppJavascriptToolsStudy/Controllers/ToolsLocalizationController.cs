using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppJavascriptToolsStudy.Models;

namespace WebAppJavascriptToolsStudy.Controllers
{
    public class ToolsLocalizationController : Controller
    {
        public ActionResult Index()
        {
            return View(new ToolsLocalizationModel());
        }
    }
}