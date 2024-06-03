namespace BL.BlApi;

public interface IBlMonthlyExpense
{
    public List<BlMonthlyExpense> GetMonthlyExpenseList(int code);
    public BlMonthlyExpense AddMonthlyExpense(BlMonthlyExpense expense);
}
