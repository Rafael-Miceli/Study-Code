namespace ChainOfResponsabilityPatternStudy
{
    public class Person
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public TicketStatus StatusAttend { get; set; }

        public Person(string name, string role, TicketStatus status)
        {
            Name = name;
            Role = role;
            StatusAttend = status;
        }

        public Person ResolvedTicket(Ticket ticket)
        {
            return ticket.TicketStatus == StatusAttend ? this : null;
        }
    }
}