namespace DAL;

public class DalManager
{
    public ITenant Tenant { get; }
    public IProposal Proposal { get; }
    public IOneTimeExpense OneTimeExpense { get; }
    public IMonthlyExpense MonthlyExpense { get; }
    public DalManager()
    {
        // אוביקט שיכיל את כל מחלקות השרות
        ServiceCollection services = new ServiceCollection();
        // מוסיפים לאוסף את אוביקט ממחלקות השרות
        services.AddSingleton<CoHousingContext>();
        services.AddScoped<ITenant, DalTenantService>();
        services.AddScoped<IProposal,DalProposalService>();
        services.AddScoped<IOneTimeExpense,DalOneTimeExpenseService>();
        services.AddScoped<IMonthlyExpense,DalMonthlyExpenseService>();

        ServiceProvider Provider = services.BuildServiceProvider();
        Tenant = Provider.GetService<ITenant>();
        Proposal = Provider.GetRequiredService<IProposal>();
        OneTimeExpense = Provider.GetService<IOneTimeExpense>();
        MonthlyExpense = Provider.GetService<IMonthlyExpense>();
    }
}


