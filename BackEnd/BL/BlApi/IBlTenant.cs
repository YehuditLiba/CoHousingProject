namespace BL.BlApi;

public interface IBlTenant
{
    public List<BlTenant> GetAll(int code);
    public BlTenant GetTenantById(string id);
    public BlTenant AddTenant(BlTenant newTenant);
    public BlTenant RemoveTenant(string id);
    public BlTenant UpdateTenant(string id, BlTenant newTenant);
}
