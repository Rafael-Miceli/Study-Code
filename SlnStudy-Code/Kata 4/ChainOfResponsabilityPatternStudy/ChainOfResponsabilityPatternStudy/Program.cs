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

        }
    }



    public class Ticket
    {
        public TicketStatus TicketStatus { get; set; }
        public string Title { get; set; }
        public Person Person { get; set; }
    }

    public enum TicketStatus
    {
        Analyse,
        Attend,
        Approving,
    }

    public class Person
    {
        public string Name { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public string Name { get; set; }
    }
}
