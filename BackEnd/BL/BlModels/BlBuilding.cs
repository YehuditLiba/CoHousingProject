namespace BL.BlModels;

public partial class BlBuilding
{
    public int BuildingCode { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    public int ZipCode { get; set; }

    public int NumOfTenants { get; set; }

    public decimal? BuildingBalance { get; set; }

    public virtual ICollection<BlMonthlyExpense> MonthlyExpenses { get; set; } = new List<BlMonthlyExpense>();

    public virtual ICollection<BlOneTimeExpense> OneTimeExpenses { get; set; } = new List<BlOneTimeExpense>();

    public virtual ICollection<BlTenant> Tenants { get; set; } = new List<BlTenant>();
}
