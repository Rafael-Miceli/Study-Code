using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var editCompanies = new EditCompaies();
            
            var companies = ModelsRepository.Companies.FirstOrDefault(c => c.Id == 1);

            editCompanies.Name = companies.Name;
            editCompanies.Id = companies.Id;
            var selectedToolsLocalizations = new List<SelectListItem>();

            if (companies.ToolsLocalizations == null)
            {
                foreach (var toolsLocalization in ModelsRepository.ToolsLocalizations)
                {
                    selectedToolsLocalizations.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = toolsLocalization.Name,
                        Value = toolsLocalization.Id.ToString()
                    });
                }

                editCompanies.ToolsLocalizationsSelected = selectedToolsLocalizations;

                return View(editCompanies);
            }



            foreach (var toolsLocalization in ModelsRepository.ToolsLocalizations)
            {
                selectedToolsLocalizations.Add(new SelectListItem
                {
                    Selected = companies.ToolsLocalizations.Any(t => t.Id == toolsLocalization.Id),
                    Text = toolsLocalization.Name,
                    Value = toolsLocalization.Id.ToString()
                });
            }

            editCompanies.ToolsLocalizationsSelected = selectedToolsLocalizations;

            return View(editCompanies);
        }

        [HttpPost]
        public ActionResult Index(EditCompaies viewModel)
        {
            var companies = ModelsRepository.Companies.FirstOrDefault(c => c.Id == viewModel.Id);

            companies.Name = viewModel.Name;

            if (viewModel.ToolsLocalizationsSelected.Any(t => t.Selected))
            {
                if (companies.ToolsLocalizations == null)
                {
                    companies.ToolsLocalizations = new Collection<ToolsLocalization>();
                }

                foreach (var selectListItem in viewModel.ToolsLocalizationsSelected)
                {
                    if (selectListItem.Selected)
                    {
                        companies.ToolsLocalizations.Add(ModelsRepository.ToolsLocalizations.FirstOrDefault(t => t.Id == int.Parse(selectListItem.Value)));
                    }
                }    
            }

            return View(viewModel);
        }
    }
}