using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EfInheritanceBehavior
{
    class Program
    {
        private static MyContext _context;
        static void Main(string[] args)
        {
            _context = new MyContext();
            _context.Database.Initialize(true);

            Console.WriteLine("Initialized Database With No Errors (I Think)...");

            CreateCheckins();

            ListCheckins();

            //FindCheckin();

            Console.ReadLine();
        }

        private static void FindCheckin()
        {
            
        }

        private static void ListCheckins()
        {
            foreach (var checkinTool in _context.CheckinTools)
            {
                Console.WriteLine("=== Checkin ===");
                Console.WriteLine(checkinTool.Holder.Name);
                Console.WriteLine(checkinTool.Tool.Name);
                Console.WriteLine(checkinTool.CheckinDateTime.Date);
            }
        }

        private static void CreateCheckins()
        {
            var checkinTool = new CheckinTool
            {
                Holder = _context.Companies.Find(4),
                CheckinDateTime = DateTime.Parse("11/12/2013"),
                Tool = _context.Tools.Find(1)
            };

            _context.CheckinTools.Add(checkinTool);

            var checkinTool2 = new CheckinTool
            {
                Holder = _context.Companies.Find(4),
                CheckinDateTime = DateTime.Parse("10/12/2013"),
                Tool = _context.Tools.Find(1)
            };

            _context.CheckinTools.Add(checkinTool2);

            var checkinTool3 = new CheckinTool
            {
                Holder = _context.Employees.Find(2),
                CheckinDateTime = DateTime.Parse("11/12/2013"),
                Tool = _context.Tools.Find(2)
            };

            _context.CheckinTools.Add(checkinTool3);

            var checkinTool4 = new CheckinTool
            {
                Holder = _context.Companies.Find(4),
                CheckinDateTime = DateTime.Parse("10/12/2013"),
                Tool = _context.Tools.Find(1)
            };

            _context.CheckinTools.Add(checkinTool4);

            _context.SaveChanges();
        }
    }
}
