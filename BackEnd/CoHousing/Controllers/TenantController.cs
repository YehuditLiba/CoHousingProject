namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class TenantController : ControllerBase
{
    IBlTenant BLtenant;
    public TenantController(BlManager blManager)
    {
        this.BLtenant = blManager.Tenant;
    }

    [HttpGet("BuildingCode/{buildingCode}")]//get list of all neighbors by building Code.
    public List<BlTenant> GetAll(int buildingCode)
    {
        return BLtenant.GetAll(buildingCode);
    }

    [HttpPost("login")]
    public BlTenant GetByEmail([FromBody] LoginRequest loginRequest)
    {
        Console.WriteLine("go to the func...");

        return BLtenant.GetByEmail(loginRequest.email, loginRequest.password);
    }

    [HttpGet("TenantId/{id}")]//Get Tenant By Id.
    public BlTenant GetTenantById(string id)
    {
        return BLtenant.GetTenantById(id);
    }

    [HttpPost]//add new tenant
    public BlTenant AddTenant([FromBody]BlTenant newTenant)
    {
        return BLtenant.AddTenant(newTenant);
    }

    [HttpDelete("{id}")]//remove tenant by id
    public BlTenant RemoveTenant(string id){
        return BLtenant.RemoveTenant(id);
    }

    [HttpPut("{id}")]//update tenant
    public BlTenant UpdateTenant(string id,[FromBody]BlTenant newTenant) 
    { 
        return BLtenant.UpdateTenant(id, newTenant);
    }
}

public class LoginRequest
{
    public string email { get; set; }
    public string password { get; set; }
}