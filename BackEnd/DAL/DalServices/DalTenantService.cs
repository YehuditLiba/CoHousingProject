using DAL.DalApi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    public class DalTenantService: ITenant
    {
        CoHousingContext _CoHousingData;
        public DalTenantService(CoHousingContext coHousingData)
        {
            _CoHousingData= coHousingData;
        }

        public List<Tenant> GetAllTenants()
        {
            return _CoHousingData.Tenants.ToList();
        }
        public List<Tenant> GetTenantsListByBuildingId(int code)
        {
            List<Tenant> list = new List<Tenant>();
            foreach(var t in _CoHousingData.Tenants)
            {
                if (t.BuildingCode == code)
                    list.Add(t);
            }
            return list;
        }
        public Tenant GetTenantByEmail(string email, string password)
        {
            var tenant = _CoHousingData.Tenants.FirstOrDefault(t => t.EmailAddress == email && t.Password == password);
            if (tenant == null)
                return null;
            return tenant;
        }
        public Tenant GetTenantById(string id)
        {
            var tenant = _CoHousingData.Tenants.FirstOrDefault(t => t.TenantId == id);
            if (tenant == null)
                return null;
            return tenant;
        }
        public Tenant AddTenant(Tenant tenant)
        {
            _CoHousingData.Tenants.Add(tenant);
            _CoHousingData.SaveChanges();
            return tenant;
        }
        public Tenant RemoveTenant(string id) 
        {
            var tenant = _CoHousingData.Tenants.FirstOrDefault(t => t.TenantId == id);
            if (tenant == null)
                return null;
            _CoHousingData.Tenants.Remove(tenant); 
            _CoHousingData.SaveChanges();
            return tenant;
        }
        public Tenant UpdateTenant(Tenant newTenant,string id)
        {
            var oldTenant = _CoHousingData.Tenants.FirstOrDefault(t => t.TenantId == id);
            if (oldTenant == null)
                return null;
            oldTenant.Balance = newTenant.Balance;
            oldTenant.Username = newTenant.Username;
            oldTenant.Password = newTenant.Password;
            oldTenant.Proposals = newTenant.Proposals;
            oldTenant.TenantId = newTenant.TenantId;
            oldTenant.BuildingCode= newTenant.BuildingCode;
            oldTenant.FirstName = newTenant.FirstName;
            oldTenant.LastName = newTenant.LastName;
            oldTenant.PhoneNumber = newTenant.PhoneNumber;
            oldTenant.ApartmentNumber = newTenant.ApartmentNumber;
            _CoHousingData.SaveChanges();
            return newTenant;
        }
    }
}
