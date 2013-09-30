using System.Collections.Generic;

namespace ConsoleAppCompositeClub
{
    public class Group: IEmailGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IEmailGroup> Members { get; set; }
        public string Email { get; set; }

        public Group()
        {
            Members = new List<IEmailGroup>();
        }
    }
}