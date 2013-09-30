using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCompositeClub
{
    public class SendEmailService
    {
        private readonly IPersonRepository _personRepository;

        public SendEmailService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Send(params IEnumerable<IEmailGroup>[] listOfPeopleToEmail)
        {

            var peopleToEmail = listOfPeopleToEmail[0].Union(listOfPeopleToEmail[1]);

            var people = _personRepository.FindPeopleEmailSended(peopleToEmail);

            foreach (var person in people.Where(p => p != null))
            {
                Console.WriteLine("Sended Email to " + person.Name + " \n");
            }
        }
    }
}
