using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppCompositeClub.Test
{
    [TestClass]
    public class PersonServiceTest
    {
        [TestMethod]
        public void Should_Get_Person()
        {
            //Arrange
            var expectedPerson = new Person
                {
                    Id = 2,
                    Name = "Rafael",
                    Email = "rafael.miceli@hotmail.com"
                };
            var personService = new PersonService(new PersonRepositoryStub());
            
            //Act
            var people = personService.GetPerson(expectedPerson.Id);

            //Assert
            Assert.AreEqual(expectedPerson.Id, people.Id);
        }

        [TestMethod]
        public void Should_Return_List_Of_Selected_Persons()
        {
            //Arrange
            var expectedPersonIdList = new List<int>
                {
                    1,
                    2
                };

            var personService = new PersonService(new PersonRepositoryStub());
            //Act

            var personIdList = personService.GetPeople(expectedPersonIdList).Select(p => p.Id).ToList();

            //Assert
            CollectionAssert.AreEqual(expectedPersonIdList, personIdList);
        }
    }

    public class PersonRepositoryStub: IPersonRepository
    {
        private readonly IEnumerable<Person> _people;

        public PersonRepositoryStub()
        {
            _people = CreatePersons();
        }

        public Person FindPerson(int id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> FindPeople(IEnumerable<int> personIdList)
        {
            return personIdList.Select(id => _people.FirstOrDefault(p => p.Id == id));
        }

        public IEnumerable<Person> FindPeopleEmailSended(IEnumerable<IEmailGroup> personIdList)
        {
            return personIdList.Select(email => _people.FirstOrDefault(p => p.Email == email.Email));
        }

        private IEnumerable<Person> CreatePersons()
        {
            var people = new List<Person>
                {
                    new Person
                        {
                            Id = 1,
                            Name = "Rafael",
                            Email = "rafael.miceli@hotmail.com"
                        },
                    new Person
                        {
                            Id = 2,
                            Name = "Priscilla",
                            Email = "priscilla.valim@outlook.com"
                        },
                    new Person
                        {
                            Id = 3,
                            Name = "Lorena",
                            Email = "lorenamiceli_@hotmail.com"
                        }
                };

            return people;
        }
    }
}
