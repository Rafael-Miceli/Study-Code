using System.Collections.Generic;

namespace ConsoleAppVisitorPatternSendEMailStudyTest
{
    public class Group
    {
        public string Name { get; set; }

        public List<ISendGroup> Members { get; set; }
    }
}