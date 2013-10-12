namespace ConsoleAppFacadePatternStudy
{
    public abstract class Turn: IExpense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class PoolTurn: Turn
    {
        
    }

    public class TenisTurn: Turn
    {
        
    }
}