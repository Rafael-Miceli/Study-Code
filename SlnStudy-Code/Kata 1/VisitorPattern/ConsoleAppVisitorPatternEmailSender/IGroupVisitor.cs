namespace ConsoleAppVisitorPatternEmailSender
{
    public interface IGroupVisitor
    {
        void Visit(Person person);
    }

    public interface IAsset
    {
        void Accept(IGroupVisitor visitor);
    }

    public class GroupVisitor: IGroupVisitor
    {
        public void Visit(Person person)
        {
            var sendEmail = new SendEmailService();
            sendEmail.Send(person);
        }
    }
}