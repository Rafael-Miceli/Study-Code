using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppVisitorPatternWithTDD.Test
{
    [TestClass]
    public class ConsoleAppCompositePatternWithTddTest
    {
        [TestMethod]
        public void Should_Send_Email_To_Person()
        {
            var person = new Person()
                {
                    Name = "Rafael",
                    Email = "rafael.miceli@hotmail.com"
                };

            var sendEmail = new SendEmailService();

            sendEmail.Send(person);

            Assert.AreEqual(PersonStaticClass.PersonStatic.Email, person.Email);
        }

        [TestMethod]
        public void Should_Send_Email_To_People()
        {
            var rafael = new Person()
            {
                Name = "Rafael",
                Email = "rafael.miceli@hotmail.com"
            };
            var priscilla = new Person()
            {
                Name = "Priscilla",
                Email = "priscilla.valim@hotmail.com"
            };
            var lorena = new Person()
            {
                Name = "Lorena",
                Email = "lorenamiceli_@hotmail.com"
            };
            var people = new List<Person> {rafael, lorena, priscilla};
            var sendEmail = new SendEmailService();

            sendEmail.Send(people);

            CollectionAssert.AreEqual(PersonStaticClass.PeopleStatic, people);
        }

        [TestMethod]
        public void Should_Send_Email_To_People_And_Groups()
        {
            var rafael = new Person()
            {
                Name = "Rafael",
                Email = "rafael.miceli@hotmail.com"
            };
            var priscilla = new Person()
            {
                Name = "Priscilla",
                Email = "priscilla.valim@hotmail.com"
            };
            var lorena = new Person()
            {
                Name = "Lorena",
                Email = "lorenamiceli_@hotmail.com"
            };
            var erick = new Person()
            {
                Name = "Erick",
                Email = "Erick.miceli@hotmail.com"
            };
            var romulo = new Person()
            {
                Name = "Romulo",
                Email = "RomuloXavier@hotmail.com"
            };
            var ricardo = new Person()
            {
                Name = "Ricardo",
                Email = "rivs10@hotmail.com"
            };
            var devs = new Group { Members = { romulo, rafael, ricardo }, Name = "Developers" };
            var people = new Group { Members = { lorena, priscilla, erick }, Name = "People" };
            var everybody = new Group { Members = { people, devs }, Name = "Everybody"};
            var sendEmail = new SendEmailService();
            var listEmails = new List<string>
                {
                    lorena.Email,
                    priscilla.Email,
                    erick.Email,
                    romulo.Email,
                    rafael.Email,
                    ricardo.Email
                };

            everybody.SendEmail();

            //everybody.SendEmail();

            CollectionAssert.AreEqual(PersonStaticClass.Emails, listEmails);

        }
    }

    public class Group: ISendEmail
    {
        public List<ISendEmail> Members { get; set; }
        public string Name { get; set; }

        public Group()
        {
            Members = new List<ISendEmail>();
        }

        public void SendEmail()
        {
            foreach (var member in Members)
            {
                member.SendEmail();
            }
        }
    }

    public interface ISendEmail
    {
        void SendEmail();
    }

    public static class PersonStaticClass
    {
        static PersonStaticClass()
        {
            Emails = new List<string>();
        }

        public static Person PersonStatic { get; set; }
        public static List<Person> PeopleStatic { get; set; }
        public static List<string> Emails { get; set; }
    }
}
