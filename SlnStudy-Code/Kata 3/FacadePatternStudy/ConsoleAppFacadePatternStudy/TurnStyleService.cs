using System;

namespace ConsoleAppFacadePatternStudy
{
    public class TurnStyleService
    {
        private readonly ITurnStyle _turnStyle;

        public TurnStyleService(ITurnStyle turnStyle)
        {
            _turnStyle = turnStyle;
        }

        public IExpense GetLast2Turned(Associate associate)
        {
            //Should return the last two spins in the TurnStyle

            return _turnStyle.GetLast2Turned(associate);
        }
    }
}