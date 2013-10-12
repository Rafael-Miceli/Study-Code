namespace ConsoleAppFacadePatternStudy
{
    public class PoolTurnStyle: ITurnStyle
    {
        public Turn GetLast2Turned(Associate associate)
        {
            return new PoolTurn
                {
                    Id = 1,
                    Name = "Ida a Piscina",
                    Price = 10.00
                };
        }
    }
}