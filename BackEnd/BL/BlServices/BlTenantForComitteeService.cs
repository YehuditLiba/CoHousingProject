namespace BL.BlServices;

public class BlTenantForComitteeService : IBlTenantForComittee
{
    ITenant DalTenant;
    IMapper mapper;
    public BlTenantForComitteeService(DalManager dalManager)
    {
        this.DalTenant = dalManager.Tenant;
    }

    public List<BlTenant> GetAll(int code)
    {
        var listFromDal = DalTenant.GetTenantsListByBuildingId(code);
        List<BlTenant> list=null;// = mapper.map<List<Tenant>>(listFromDal);

        //foreach (var t in listFromDal)
        //{
        //    list.Add(new Tenant()
        //    {
        //        ApartmentNumber = t.ApartmentNumber,
        //        FirstName = t.FirstName,
        //        LastName = t.LastName,
        //        Balance = t.Balance,
        //        PhoneNumber = t.PhoneNumber,
        //        EmailAddress = t.EmailAddress
        //    });
        //}
        return list;
    }
}

