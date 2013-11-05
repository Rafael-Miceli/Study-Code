namespace ChainOfResponsabilityPatternStudy
{
    public class TicketStatusHandler: ITicketStatusHandler
    {
        private readonly Person _resolver;
        private ITicketStatusHandler _next;

        public TicketStatusHandler(Person person)
        {
            _resolver = person;
        }

        public Person ResolveTicket(Ticket ticket)
        {
            var resolver = _resolver.ResolvedTicket(ticket);

            return resolver ?? _next.ResolveTicket(ticket);
        }

        public void RegisterNext(ITicketStatusHandler status)
        {
            _next = status;
        }
    }
}