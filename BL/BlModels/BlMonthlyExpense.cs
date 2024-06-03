namespace BL.BlModels;

public partial class BlMonthlyExpense
{
    public int ExpenditureId { get; set; }

    public int BuildingCode { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? Date { get; set; }

    public virtual BlBuilding BuildingCodeNavigation { get; set; } = null!;
}
