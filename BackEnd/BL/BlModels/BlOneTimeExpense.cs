namespace BL.BlModels;

public partial class BlOneTimeExpense
{
    public int ExpenditureId { get; set; }

    public int BuildingCode { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? Date { get; set; }

    public decimal Total { get; set; }

    public virtual BlBuilding BuildingCodeNavigation { get; set; } = null!;
}
