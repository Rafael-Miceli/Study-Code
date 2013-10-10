namespace ConsoleAppVisitorPatternEmailSender
{
    public class Person: IAsset
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public void Accept(IGroupVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}