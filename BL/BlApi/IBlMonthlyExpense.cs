namespace BL.BlApi;

public interface IBlMonthlyExpense
{
    public List<MonthlyExpense> GetMonthlyExpenseList(int code);
    public MonthlyExpense AddMonthlyExpense(MonthlyExpense expense);
}
