namespace ChainOfResponsabilityPatternStudy
{
    public interface ITicketStatusHandler
    {
        Person ResolveTicket(Ticket ticket);
        void RegisterNext(ITicketStatusHandler status);
    }
}