using System;

namespace ConsoleAppFacadePatternStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var associateService = new AssociateService();
            var associate = associateService.GetAssociate(2);

            var expenseService = new ExpenseService();
            var expenseList = expenseService.GetAssociateExpenses(associate);

            foreach (var expense in expenseList)
            {
                Console.WriteLine(expense.Name);    
            }

            Console.ReadKey();
        }
    }
}
