namespace ConsoleAppVisitorPatternSendEmailStudy
{
    public class Person: IEmailSender
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public void Accept(IGroupVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}