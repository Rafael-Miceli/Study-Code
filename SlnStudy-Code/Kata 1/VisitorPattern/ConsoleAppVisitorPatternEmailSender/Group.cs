using System.Collections.Generic;

namespace ConsoleAppVisitorPatternEmailSender
{
    public class Group: IAsset
    {
        public List<IAsset> Members { get; set; }

        public Group()
        {
            Members = new List<IAsset>();
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