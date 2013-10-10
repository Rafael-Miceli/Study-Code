using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var rafael = new Person()
                {
                    Name = "Rafael",
                    Email = "rafael.miceli@hotmail.com"
                };
            var priscilla = new Person()
                {
                    Name = "Priscilla",
                    Email = "priscilla.valim@outlook.com"
                };
            var lorena = new Person()
            {
                Name = "Lorena",
                Email = "lorenamiceli_@hotmail.com"
            };
            var romulo = new Person()
            {
                Name = "Romulo",
                Email = "romulo@outlook.com"
            };
            var ricardo = new Person()
            {
                Name = "Ricardo",
                Email = "rivs10@hotmail.com"
            };
            var erick = new Person()
            {
                Name = "Erick",
                Email = "erick.roland@outlook.com"
            };

            var devs = new Group()
                {
                    Members = {ricardo, romulo, rafael}
                };

            var groups = new Group() {Members = {devs, lorena, priscilla, erick}};
            groups.Send();

            //var sendEmail = new SendEmailService();
            //sendEmail.Send(groups);
            

            Console.ReadKey();
        }
    }
}
