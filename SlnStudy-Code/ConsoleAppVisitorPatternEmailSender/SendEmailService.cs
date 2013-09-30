using System;

namespace ConsoleAppVisitorPatternEmailSender
{
    public class SendEmailService
    {
        public void Send(Person person)
        {
            Console.WriteLine("Sended Email to " + person.Name);
        }
    }
}