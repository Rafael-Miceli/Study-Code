package ChainOfResponsabilityPatternStudy;

public interface IExpenseApprover 
{
	ApprovalResponse approvalExpense(IExpenseReport expenseReport); 
}