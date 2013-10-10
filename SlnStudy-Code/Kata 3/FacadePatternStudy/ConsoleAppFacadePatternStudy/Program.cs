using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFacadePatternStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var associateService = new AssociateService();
            var associate = associateService.GetAssociate(2);

            var itemsService = new itemsService();
            var expenseList = new ExpenseList();
            expenseList.Add(itemsService.GetLast5BuyedItems(associate));

            var turnStilePoolService = new TurnStileService(PoolTurnStile);
            var turnStileTenisService = new TurnStileService(TenisTrunStile);

            expenseList.Add(turnStilePoolService.GetLast2Turned(associate));
            expenseList.Add(turnStileTenisService.GetLast2Turned(associate));

            foreach (var expense in expenseList)
            {
                Console.WriteLine(expense.Name);    
            }

            Console.ReadKey();
        }
    }
}
