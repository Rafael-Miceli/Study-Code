namespace ChainOfResponsabilityPatternStudy
{
    public class Ticket
    {
        public TicketStatus TicketStatus { get; set; }
        public string Title { get; set; }
        public Person Person { get; set; }

        public Ticket(string title)
        {
            Title = title;
            TicketStatus = TicketStatus.Open;
        }

        public Ticket(string title, TicketStatus status)
        {
            Title = title;
            TicketStatus = status;
        }
    }
}