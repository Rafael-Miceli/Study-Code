package ChainOfResponsabilityPatternStudy;

import java.util.ArrayList;
import java.util.List;

import javax.swing.JOptionPane;

public class Main {
	
	public static void main(String args[])
	{
		List<Employee> managers = new ArrayList<Employee>();
		
		managers.add(new Employee("Rafael Miceli", 0));
		managers.add(new Employee("Lorena Miceli", 1000));
		managers.add(new Employee("Priscilla Valim", 20000));
		managers.add(new Employee("Erick Rolan", 5000));
		
		Double expenseReportAmount = 0.0;
		expenseReportAmount = Double.valueOf(JOptionPane.showInputDialog("Type the value"));
				
		System.out.println(expenseReportAmount);
		
		while(expenseReportAmount.getClass() == Double.class)
		{
			IExpenseReport expense = new ExpenseReport(expenseReportAmount);
			
			Boolean expenseProcessed = false;
			
			for(Employee approver : managers)
			{
				ApprovalResponse response = approver.approvalExpense(expense);
				
				if(response != ApprovalResponse.BeyondApprovalLimit)
				{
					System.out.println("The request was " + response.toString());
					expenseProcessed = true;
					break;
				}					
			}
			
			if (!expenseProcessed)
				System.out.println("No one was able to approve your expense");
			
			expenseReportAmount = Double.valueOf(JOptionPane.showInputDialog("Type the value"));
		}
	}

}
