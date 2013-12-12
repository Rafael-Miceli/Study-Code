using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EfInheritanceBehavior
{
    public class MyContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<CheckinTool> CheckinTools { get; set; }

        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }

        public MyContext(): base("DefaultConnection")
        {}
    }

    public class IntId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class CheckinTool : IntId
    {
        public virtual Tool Tool { get; set; }
        public virtual Holder Holder { get; set; }
        public virtual DateTime CheckinDateTime { get; set; }
    }

    public class Tool : IntId
    {
        public virtual string Name { get; set; }
    }

    public class Company: Holder
    {
        public virtual string City { get; set; }
    }

    public class Employee: Holder
    {
        public virtual string Phone { get; set; }
    }

    public class Holder : IntId
    {
        public virtual string Name { get; set; }
    }
}
