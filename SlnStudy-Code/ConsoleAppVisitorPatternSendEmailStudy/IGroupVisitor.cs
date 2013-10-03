namespace ConsoleAppVisitorPatternSendEmailStudy
{
    public interface IGroupVisitor
    {
        void Visit(Person visitor);
    }

    public interface IEmailSender
    {
        void Accept(IGroupVisitor visitor);
    }
}