using System.Collections.Generic;

namespace ConsoleAppCompositeClub
{
    public interface IPersonRepository
    {
        Person FindPerson(int id);
        IEnumerable<Person> FindPeople(IEnumerable<int> personIdList);
        IEnumerable<Person> FindPeopleEmailSended(IEnumerable<IEmailGroup> personIdList);
    }
}