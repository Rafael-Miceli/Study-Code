namespace ConsoleAppFacadePatternStudy
{
    public class AssociateService
    {
        public Associate GetAssociate(int i)
        {
            return new Associate
                {
                    Id = i,
                    Name = "Rafael"
                };
        }
    }
}