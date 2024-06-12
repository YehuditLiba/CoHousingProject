using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DAL.DalApi;

public interface ITenant
{
    public List<Tenant> GetTenantsListByBuildingId(int code);
    public Tenant GetTenantById(string id);
    public Tenant GetTenantByEmail(string email, string password);
    public Tenant AddTenant(Tenant tenant);
    public Tenant RemoveTenant(string id);
    public Tenant UpdateTenant(Tenant newTenant, string id);
}
