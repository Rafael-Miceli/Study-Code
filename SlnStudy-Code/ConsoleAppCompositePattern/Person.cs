using System;

namespace ConsoleAppCompositePattern
{
    public class Person: IEmailSend
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public void Send()
        {
            Console.WriteLine("Sended Email to " + Name);
        }
    }
}