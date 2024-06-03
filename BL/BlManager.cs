namespace BL;
public class BlManager
{
    public IBlTenant Tenant { get;}
    public IBlProposal Proposal { get; }
    public IBlOneTimeExpense OneTimeExpense { get; }
    public IBlMonthlyExpense MonthlyExpense { get; }

    public BlManager()
    { 
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<DalManager>();
        services.AddScoped<IBlTenant,BlTenantService>();
        services.AddScoped<IBlProposal,BlProposalService>();
        services.AddScoped<IBlOneTimeExpense,BlOneTimeExpenseService>();
        services.AddScoped<IBlMonthlyExpense, BlMonthlyExpenseService>();
        services.AddAutoMapper(typeof(BlProfile));

        ServiceProvider provider = services.BuildServiceProvider();
        Tenant=provider.GetRequiredService<IBlTenant>();
        Proposal = provider.GetRequiredService<IBlProposal>();
        OneTimeExpense = provider.GetRequiredService<IBlOneTimeExpense>();
        MonthlyExpense =provider.GetRequiredService<IBlMonthlyExpense>();
    }
}
