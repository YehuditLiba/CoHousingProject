namespace WebApi.Controllers;

[ApiController]
[Route("api/ME")]
public class MonthlyExpenseController : ControllerBase
{
    IBlMonthlyExpense MonthlyExpense;
    public MonthlyExpenseController (BlManager blmanager)
    {
        this.MonthlyExpense = blmanager.MonthlyExpense;
    }

    [HttpGet("{code}")]
    public List<BlMonthlyExpense> GetAll(int code)
    {
        return MonthlyExpense.GetMonthlyExpenseList(code);
    }
}
