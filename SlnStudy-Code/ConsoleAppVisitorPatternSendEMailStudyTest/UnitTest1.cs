using System;
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
            
        }
    }

    public static class PersonStaticClass
    {
        public static Person StaticPerson { get; set; }
    }
}
