using System;
using System.Collections.Generic;

namespace ConsoleAppCompositePattern
{
    public class SendEmailService
    {
        public void Send(Group group)
        {
            foreach (var member in group.Members)
            {
                Console.WriteLine("Sended Email to " + member.Name);        
            }
        }
    }
}