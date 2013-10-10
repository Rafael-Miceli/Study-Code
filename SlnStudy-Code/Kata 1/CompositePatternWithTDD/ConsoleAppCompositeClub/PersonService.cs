using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppCompositeClub
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetPerson(int id)
        {
            return _personRepository.FindPerson(id);
        }

        public IEnumerable<Person> GetPeople(IEnumerable<int> expectedPersonIdList)
        {
            return _personRepository.FindPeople(expectedPersonIdList);
        }
    }
}