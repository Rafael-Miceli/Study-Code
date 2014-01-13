using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebAppJavascriptToolsStudy.Models
{
    public static class ModelsRepository
    {
        public static List<ToolsLocalization> ToolsLocalizations;
        public static List<Company> Companies;

        static ModelsRepository()
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

            Companies = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "Portoverano",
                    ToolsLocalizations = new Collection<ToolsLocalization>
                    {
                        ToolsLocalizations.Find(t => t.Id == 1),
                        ToolsLocalizations.Find(t => t.Id == 3),
                    }
                },
                new Company
                {
                    Id = 2,
                    Name = "Portomare"
                },
                new Company
                {
                    Id = 3,
                    Name = "Portofino"
                }
            };
        }
    }
}