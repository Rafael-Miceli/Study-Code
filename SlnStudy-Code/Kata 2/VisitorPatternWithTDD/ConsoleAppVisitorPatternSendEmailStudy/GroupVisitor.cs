namespace ConsoleAppVisitorPatternSendEmailStudy
{
    public class GroupVisitor: IGroupVisitor
    {
        public void Visit(Person visitor)
        {
            var sendEmail = new SendEmailService();
            sendEmail.Send(visitor);
        }
    }
}