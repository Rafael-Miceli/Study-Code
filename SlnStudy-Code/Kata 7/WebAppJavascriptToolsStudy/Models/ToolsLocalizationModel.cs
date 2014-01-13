using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppJavascriptToolsStudy.Models
{
    public class EditCompaies
    {
        public IList<SelectListItem> ToolsLocalizationsWithCompany { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToolsLocalization> ToolsLocalizations { get; set; }


        public EditCompaies()
        {
            ToolsLocalizations = ModelsRepository.ToolsLocalizations;

            var toolsLocalizationsWithCompany = new List<SelectListItem>();

            foreach (var toolsLocalization in ToolsLocalizations)
            {
                toolsLocalizationsWithCompany.Add(new SelectListItem
                {
                    Selected = 
                });
            }
        }

        

    }

    public class ToolsLocalization
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Company> Companies { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToolsLocalization> ToolsLocalizations { get; set; }
    }
}