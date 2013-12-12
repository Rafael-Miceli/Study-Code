namespace EfInheritanceBehavior.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            CreateEmployees(context);
            CreateCompanies(context);
            CreateTools(context);

            base.Seed(context);
        }

        private void CreateTools(MyContext context)
        {
            context.Tools.AddOrUpdate(p => p.Name,
                new Tool { Name = "Ferramenta 1" },
                new Tool { Name = "Ferramenta 2" },
                new Tool { Name = "Ferramenta 3" });
        }

        private void CreateCompanies(MyContext context)
        {
            context.Companies.AddOrUpdate(p => p.Name,
                new Company { Name = "Condominio 1", City = "Rio de Janeiro"},
                new Company { Name = "Condominio 2", City = "São Paulo"},
                new Company { Name = "Condominio 3", City = "Espírito Santo"});
        }

        private void CreateEmployees(MyContext context)
        {
            context.Employees.AddOrUpdate(p => p.Name,
                new Employee { Name = "Rafael", Phone = "8802-3900" },
                new Employee { Name = "Lorena", Phone = "8802-3911" },
                new Employee { Name = "Priscilla", Phone = "7943-1622" });
        }
    }
}
