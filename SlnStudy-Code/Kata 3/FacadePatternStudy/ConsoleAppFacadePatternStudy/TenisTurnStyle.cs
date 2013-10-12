namespace ConsoleAppFacadePatternStudy
{
    public class TenisTurnStyle: ITurnStyle
    {
        public Turn GetLast2Turned(Associate associate)
        {
            return new TenisTurn
            {
                Id = 1,
                Name = "Ida a quadra de Tênis",
                Price = 20.00
            };
        }
    }
}