namespace DAL.Models;

public partial class MonthlyExpense
{
    public int ExpenditureId { get; set; }

    public int BuildingCode { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? Date { get; set; }

    public virtual Building BuildingCodeNavigation { get; set; } = null!;
}
