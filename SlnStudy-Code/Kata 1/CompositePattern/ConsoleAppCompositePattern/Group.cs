using System.Collections.Generic;

namespace ConsoleAppCompositePattern
{
    public class Group: IEmailSend
    {
        public string Name { get; set; }
        public List<IEmailSend> Members { get; set; }

        public Group()
        {
            Members = new List<IEmailSend>();  
        }

        public void Send()
        {
            foreach (var member in Members)
            {
                member.Send();
            }
        }
    }

    public interface IEmailSend
    {
        string Name { get; set; }
        void Send();
    }
}