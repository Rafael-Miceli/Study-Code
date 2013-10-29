package ChainOfResponsabilityPatternStudy;

public class Employee implements IExpenseApprover 
{
	private double _approvalLimit;
	private String Name;

	public Employee(String name, double approvalLimit)
	{
		setName(name);
		_approvalLimit = approvalLimit;
	}

	@Override
	public ApprovalResponse approvalExpense(IExpenseReport expenseReport) {		
		return (expenseReport.getTotal() > _approvalLimit ?
				ApprovalResponse.BeyondApprovalLimit: 
					ApprovalResponse.Approved);
	}

	private void setName(String name) {
		Name = name;
	}

	public String getName() {
		return Name;
	}

}
