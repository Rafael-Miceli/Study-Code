using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainOfResponsabilityPatternStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //No  CoR

            /*
            var ticket1 = new Ticket("Ticket 1");
            var ticket2 = new Ticket("Ticket 2", TicketStatus.WaitingPieces);
            var ticket3 = new Ticket("Ticket 3", TicketStatus.Resolved);

            var celso = new Person("Celso", "Tec 3", TicketStatus.Open);
            var talita = new Person("Talita", "Atendente", TicketStatus.Resolved);
            var mike = new Person("Mike", "Tec 1", TicketStatus.Open);
            var tino = new Person("Tino", "Administrador", TicketStatus.WaitingPieces);

            var people = new List<Person>
                {
                    celso,
                    talita,
                    mike,
                    tino
                };
            var tickets = new List<Ticket>
                {
                    ticket1,
                    ticket2,
                    ticket3
                };

            foreach (var ticket in tickets)
            {
                foreach (var person in people)
                {
                    if (ticket.TicketStatus == person.StatusAttend)
                    {
                        Console.WriteLine(person.Name + " Resolved the problem of " + ticket.Title);
                    }
                }
            }
             * 
             */


            //With Cor


        }
    }
}
