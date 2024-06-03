namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProposalController : ControllerBase
{
    IBlProposal BlProposal;
    public ProposalController(BlManager blManager)
    {
        this.BlProposal = blManager.Proposal;
    }

    [HttpGet("BuildingCode/{code}")] //get all proposals of building.
    public List<BlProposal> GetAllProposals(int code)
    {
        return BlProposal.GetAllProposals(code);
    }

    [HttpPost] //add a new proposal.
    public BlProposal AddNewProposal([FromQuery]string id,string description)
    {
        return BlProposal.AddNewProposal(id, description);
    }


}
