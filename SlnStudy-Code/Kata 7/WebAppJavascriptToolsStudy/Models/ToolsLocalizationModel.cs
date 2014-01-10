using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppJavascriptToolsStudy.Models
{
    public class ToolsLocalizationModel
    {

        public List<ToolsLocalization> ToolsLocalizations;

        public ToolsLocalizationModel()
        {
            ToolsLocalizations = new List<ToolsLocalization>
            {
                new ToolsLocalization
                {
                    Id = 1,
                    Name = "Portão de garagem"
                },
                new ToolsLocalization
                {
                    Id = 2,
                    Name = "Portão de pedestres"
                },
                new ToolsLocalization
                {
                    Id = 3,
                    Name = "Hall de visitantes"
                },
                new ToolsLocalization
                {
                    Id = 4,
                    Name = "Portão de Moradores"
                },
                new ToolsLocalization
                {
                    Id = 5,
                    Name = "Entrada de Veículos"
                },
                new ToolsLocalization
                {
                    Id = 6,
                    Name = "P1"
                },
                new ToolsLocalization
                {
                    Id = 7,
                    Name = "P2"
                },
                new ToolsLocalization
                {
                    Id = 8,
                    Name = "P3"
                }
            };
        }

        

    }

    public class ToolsLocalization
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}