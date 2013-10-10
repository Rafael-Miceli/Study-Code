using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppCompositeClub.Test
{
    [TestClass]
    public class SendEmailTest
    {
        [TestMethod]
        public void Should_Send_Email_To_Selected_People()
        {
            //Arrange
            var peopleList = new List<Person>
                {
                    new Person
                        {
                            Id = 1,
                            Name = "Rafael",
                            Email = "rafael.miceli@hotmail.com"
                        },
                    new Person()
                        {
                            Id = 2,
                            Name = "Priscilla",
                            Email = "priscilla.valim@outlook.com"
                        }
                };

                var sendEmail = new SendEmailService(new PersonRepositoryStub());
            //Act
            sendEmail.Send(peopleList);
        }

        [TestMethod]
        public void Should_Send_Email_To_Selected_People_And_Group()
        {
            //Arrange

            var peopleList = new List<Person>
                {
                    new Person
                        {
                            Id = 1,
                            Name = "Rafael",
                            Email = "rafael.miceli@hotmail.com"
                        },
                    new Person()
                        {
                            Id = 2,
                            Name = "Priscilla",
                            Email = "priscilla.valim@outlook.com"
                        }
                };

            var developers = new List<Group>
                {
                    new Group
                    {
                        Id = 1,
                        Name = "Developers",
                        Email = "developers_rafael_miceli@hotmail.com",
                        Members =
                            {
                                new Person
                                    {
                                        Id = 3,
                                        Name = "Romulo",
                                        Email = "romuloxavier@hotmai.co"
                                    },
                                new Person
                                    {
                                        Id = 4,
                                        Name = "Lorena",
                                        Email = "lorenamiceli_@hotmail.com"
                                    }
                            }
                    }
                };

            var sendEmail = new SendEmailService(new PersonRepositoryStub());
            //Act
            sendEmail.Send(peopleList, developers);
        }
    }
}
