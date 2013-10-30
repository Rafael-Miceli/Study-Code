package ChainOfResponsabilityPatternStudy;


public class ExpenseReport implements IExpenseReport 
{
	public ExpenseReport(double total)
	{
		_total = total;
	}

	private double _total;
	
	@Override
	public double getTotal() 
	{
		return _total;
	}

}
