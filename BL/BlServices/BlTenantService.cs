using AutoMapper;
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
    public List<BL.BlModels.Tenant> GetAll(int code)
    {
        List<BL.BlModels.Tenant> list = new List<BL.BlModels.Tenant>();
      
        var listFromDal = DalTenant.GetTenantsListByBuildingId(code);
      
        listFromDal.ForEach(t => list.Add(mapper.Map<BL.BlModels.Tenant>(t)));
        return list;
    }

}
