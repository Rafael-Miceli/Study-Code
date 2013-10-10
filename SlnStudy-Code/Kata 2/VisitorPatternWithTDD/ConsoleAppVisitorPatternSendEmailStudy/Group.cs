using System.Collections.Generic;

namespace ConsoleAppVisitorPatternSendEmailStudy
{
    public class Group: IEmailSender
    {
        public string Name { get; set; }
        public List<IEmailSender> Members { get; set; }

        public Group()
        {
            Members = new List<IEmailSender>();
        }

        public void Accept(IGroupVisitor visitor)
        {
            foreach (var member in Members)
            {
                member.Accept(visitor);
            }
        }
    }

}