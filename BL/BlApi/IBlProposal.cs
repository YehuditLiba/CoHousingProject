namespace BL.BlApi;

public interface IBlProposal
{
    public List<BlProposal> GetAllProposals(int code);
    public BlProposal AddNewProposal(string id, string description);
    public BlProposal RemoveProposal(BlProposal Proposal);
    public void TellTheNeighbors(BlProposal newProposal);
}
