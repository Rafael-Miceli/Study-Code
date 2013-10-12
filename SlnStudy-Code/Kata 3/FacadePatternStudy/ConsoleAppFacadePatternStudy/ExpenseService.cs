using System.Collections.Generic;

namespace ConsoleAppFacadePatternStudy
{
    //This is a "facade" class
    public class ExpenseService
    {
        public IEnumerable<IExpense> GetAssociateExpenses(Associate associate)
        {
            var itemsService = new ItemsService();
            var turnStilePoolService = new TurnStyleService(new PoolTurnStyle());
            var turnStileTenisService = new TurnStyleService(new TenisTurnStyle());

            var expenseList = new List<IExpense>
                {
                    itemsService.GetLast5BuyedItems(associate),
                    turnStilePoolService.GetLast2Turned(associate),
                    turnStileTenisService.GetLast2Turned(associate)
                };

            return expenseList;
        }
    }
}