using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface ITenant
    {
        public List<Tenant> GetTenantsListByBuildingId(int code);
        public Tenant GetTenantById(string id);
        public Tenant AddTenant(Tenant tenant);
        public Tenant RemoveTenant(string id);
        public Tenant UpdateTenant(Tenant newTenant, string id);
    }
}
