namespace ConsoleAppVisitorPatternWithTDD.Test
{
    public class Person: ISendEmail
    {
        public string Name{ get; set; }
        public string Email{ get; set; }

        public void SendEmail()
        {
            var sendEmail = new SendEmailService();
            sendEmail.Send(Email);
        }
    }
}