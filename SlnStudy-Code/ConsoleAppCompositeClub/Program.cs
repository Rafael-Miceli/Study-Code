using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCompositeClub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing send Email");
            Console.WriteLine("");

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


            var sendEmail = new SendEmailService(new PersonRepository());
            sendEmail.Send(peopleList, developers);

            Console.ReadKey();
        }
    }

    public class PersonRepository: IPersonRepository
    {
        private readonly IEnumerable<Person> _people;

        public PersonRepository()
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
                        },
                    new Person
                        {
                            Id = 3,
                            Name = "Romulo",
                            Email = "romuloxavier@hotmai.co"
                        }
                };

            return people;
        }
    }
}
