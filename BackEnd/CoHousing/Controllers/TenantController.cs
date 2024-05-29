namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantController : ControllerBase
{
    IBlTenant BLtenant;
    public TenantController(BlManager blManager)
    {
        this.BLtenant = blManager.Tenant;
    }

    [HttpGet("{code}")]
    public List<Tenant> GetAll(int code) {
       return BLtenant.GetAll(code);
    }


}
