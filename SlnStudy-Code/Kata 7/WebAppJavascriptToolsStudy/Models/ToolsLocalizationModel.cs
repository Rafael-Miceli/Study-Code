using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppJavascriptToolsStudy.Models
{
    public class EditCompaies
    {
        public IList<SelectListItem> ToolsLocalizationsSelected { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToolsLocalization> AllToolsLocalizations { get; set; }


        public EditCompaies()
        {
        }

        

    }

#region Domain Models

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

    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ToolCheckin
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public DateTime DateTimeCheckin { get; set; }
        public int CompanyId { get; set; }
    }

#endregion
}