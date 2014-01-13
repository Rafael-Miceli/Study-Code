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
            return View(new EditCompaies());
        }

        [HttpPost]
        public ActionResult Index(EditCompaies viewModel)
        {
            foreach (var toolsLocalization in viewModel.ToolsLocalizations)
            {
                Console.WriteLine(toolsLocalization.Id);
                Console.WriteLine(toolsLocalization.Name);    
            }
        }
    }
}