using DAL.Models;

namespace BL.BlServices;
public class BlTenantService : IBlTenant
{
    ITenant DalTenant;
    IMapper mapper;
    public BlTenantService(DalManager dalManager) 
    {
        this.DalTenant = dalManager.Tenant;
        //  var config = new MapperConfiguration(cfg => cfg.CreateMap<DAL.Models.Tenant,BL.BlModels.Tenant >());
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BlProfile>());
        mapper = config.CreateMapper();
    }
    public List<BlTenant> GetAllTenants()
    {
        List<BlTenant> list = new List<BlTenant>();
        var listFromDal = DalTenant.GetAllTenants();
        listFromDal.ForEach(t => list.Add(mapper.Map<BlTenant>(t)));
        return list;
    }
    public List<BlTenant> GetTenantsByBuildingCode(int code)
    {
        List<BlTenant> list = new List<BlTenant>();
        var listFromDal = DalTenant.GetTenantsListByBuildingId(code);
        listFromDal.ForEach(t => list.Add(mapper.Map<BlTenant>(t)));
        return list;
    }
    public BlTenant GetByEmail(string email, string password)
    {
        return mapper.Map<BlTenant>(DalTenant.GetTenantByEmail(email,password));
    }
    public BlTenant GetTenantById(string id)
    {
        return mapper.Map<BlTenant>(DalTenant.GetTenantById(id));
    }
    public BlTenant AddTenant(BlTenant newTenant)
    {
        Tenant tenantToAdd = mapper.Map<Tenant>(newTenant);
        DalTenant.AddTenant(tenantToAdd);
        return mapper.Map<BlTenant>(tenantToAdd);
    }
    public BlTenant RemoveTenant(string id)
    {
        return mapper.Map<BlTenant>(DalTenant.RemoveTenant(id));
    }
    public BlTenant UpdateTenant(string id, BlTenant newTenant)
    {
        Tenant tenantToUpdate = mapper.Map<Tenant>(newTenant);
        DalTenant.UpdateTenant(tenantToUpdate, id);
        return mapper.Map<BlTenant>(tenantToUpdate);
    }
}
