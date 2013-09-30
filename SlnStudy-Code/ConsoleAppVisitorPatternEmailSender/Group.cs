using System.Collections.Generic;

namespace ConsoleAppVisitorPatternEmailSender
{
    public class Group
    {
        public List<Person> Members { get; set; }

        public Group()
        {
            Members = new List<Person>();
        }
    }
}