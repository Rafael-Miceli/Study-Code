using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebAppJavascriptToolsStudy.Models
{
    public static class ModelsRepository
    {
        public static List<ToolsLocalization> ToolsLocalizations;
        public static List<Company> Companies;
        public static List<Tool> Tools;
        public static List<ToolCheckin> ToolCheckins; 

        static ModelsRepository()
        {
            #region ToolsLocalization Initializer
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
            #endregion

            #region Company Initializer

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

            #endregion

            #region Tool Initializer

            Tools = new List<Tool>
            {
                new Tool
                {
                    Id = 1,
                    Name = "Ferramenta 1"
                },
                new Tool
                {
                    Id = 2,
                    Name = "Ferramenta 2"
                }
            };

            #endregion

            #region ToolCheckin Initializer

            ToolCheckins = new List<ToolCheckin>
            {
                new ToolCheckin
                {
                    Id = 1,
                    ToolId = 1,
                    CompanyId = 1,
                    DateTimeCheckin = new DateTime(2013, 11, 12)
                },
                new ToolCheckin
                {
                    Id = 2,
                    ToolId = 1,
                    CompanyId = 2,
                    DateTimeCheckin = new DateTime(2013, 11, 13)
                },
                new ToolCheckin
                {
                    Id = 3,
                    ToolId = 1,
                    CompanyId = 1,
                    DateTimeCheckin = new DateTime(2013, 11, 14)
                }
            };

            #endregion
        }
    }
}