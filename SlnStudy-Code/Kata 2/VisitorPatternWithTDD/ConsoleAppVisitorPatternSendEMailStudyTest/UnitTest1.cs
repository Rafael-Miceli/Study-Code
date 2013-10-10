using System;
using ConsoleAppVisitorPatternSendEmailStudy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppVisitorPatternSendEMailStudyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Should_Send_Email_To_A_Person()
        {
            var person = new Person()
                {
                    Name = "Rafael",
                    Email = "rafael.miceli@hotmail.com"
                };

            var sendEmail = new SendEmailService();
            sendEmail.Send(person);

            Assert.AreEqual(PersonStaticClass.StaticPerson, person);
        }

        [TestMethod]
        public void Should_Send_Email_To_Group()
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

            var devs = new Group
                {
                    Name = "Developers",
                    Members = {rafael, romulo, ricardo}
                };

            var users = new Group
                {
                    Name = "Users",
                    Members = {lorena, priscilla, erick}
                };

            var everybody = new Group()
                {
                    Members = {devs, users}
                };

            var groupVisitor = new GroupVisitor();

            everybody.Accept(groupVisitor);

        }
    }

    public static class PersonStaticClass
    {
        public static Person StaticPerson { get; set; }
    }
}
