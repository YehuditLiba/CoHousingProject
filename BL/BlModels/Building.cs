namespace BL.BlModels;

public partial class Building
{
    public int BuildingCode { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int HouseNumber { get; set; }

    public int ZipCode { get; set; }

    public int NumOfTenants { get; set; }

    public decimal? BuildingBalance { get; set; }

    public virtual ICollection<MonthlyExpense> MonthlyExpenses { get; set; } = new List<MonthlyExpense>();

    public virtual ICollection<OneTimeExpense> OneTimeExpenses { get; set; } = new List<OneTimeExpense>();

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
