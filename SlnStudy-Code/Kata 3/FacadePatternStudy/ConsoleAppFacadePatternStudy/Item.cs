
namespace ConsoleAppFacadePatternStudy
{
    public class Item: IExpense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}