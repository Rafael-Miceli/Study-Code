namespace ConsoleAppVisitorPatternSendEMailStudyTest
{
    public class SendEmailService
    {
        public void Send(Person person)
        {
            PersonStaticClass.StaticPerson = person;
        }
    }
}