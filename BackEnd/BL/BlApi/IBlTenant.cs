namespace BL.BlApi;

public interface IBlTenant
{
    public List<BlTenant> GetAllTenants();
    public List<BlTenant> GetTenantsByBuildingCode(int code);
    public BlTenant GetByEmail(string email, string password);
    public BlTenant GetTenantById(string id);
    public BlTenant AddTenant(BlTenant newTenant);
    public BlTenant RemoveTenant(string id);
    public BlTenant UpdateTenant(string id, BlTenant newTenant);
}
