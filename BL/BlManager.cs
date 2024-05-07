namespace BL;

public class BlManager
{
    public IBlTenant Tenant { get;}
//      public IBlTenantForComittee TenantForComittee { get; }
    public IBlMonthlyExpense MonthlyExpense { get; }

    public BlManager()
    { 
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<DalManager>();
        services.AddScoped<IBlTenant,BlTenantService>();
//          services.AddScoped<IBlTenantForComittee, BlTenantForComitteeService>();
        services.AddScoped<IBlMonthlyExpense, BlMonthlyExpenseService>();
        services.AddAutoMapper(typeof(BlProfile));

        ServiceProvider provider = services.BuildServiceProvider();
        Tenant=provider.GetRequiredService<IBlTenant>();
//          TenantForComittee = provider.GetRequiredService<IBlTenantForComittee>();
        MonthlyExpense=provider.GetRequiredService<IBlMonthlyExpense>();
    }
}
