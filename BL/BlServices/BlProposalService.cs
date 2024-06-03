namespace BL.BlServices;

using BL.BlModels;
using BlApi;
using DAL.Models;

public class BlProposalService : IBlProposal
{
    IProposal DalProposal;
    IMapper mapper;
    IBlTenant IBlTenant;
    public BlProposalService(DalManager dalManager)
    {
        this.DalProposal = dalManager.Proposal;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<BlProfile>());
        mapper = config.CreateMapper();
    }

    public List<BlProposal> GetAllProposals(int code)
    {
        List<BlProposal> list = new List<BlProposal>();
        var listFromDal = DalProposal.GetProposalsListByBuildingCode(code);
        listFromDal.ForEach(p => list.Add(mapper.Map<BlProposal>(p)));
        return list;
    }
    public BlProposal AddNewProposal(string id,string description)
    {
        BlProposal newProposal = new BlProposal();
        newProposal.Description = description;
        newProposal.TenantId = id;
        DalProposal.AddProposal(mapper.Map<Proposal>(newProposal));
        TellTheNeighbors(newProposal);
        return newProposal;
    }

    public BlProposal RemoveProposal(BlProposal proposal)
    {
        return mapper.Map<BlProposal>(DalProposal.RemoveProposal(proposal.ProposalId));
    }

    /// <summary>
    /// A function responsible for updating all neighbors and sending them an appropriate message
    ///לשדרג שיוכלו לשלוח מחרוזת ואותה זה ידפיס בהתאם לצורך    
    /// </summary>
    /// <param name="newProposal"></param>
    public void TellTheNeighbors(BlProposal newProposal)
    {
        List<BlTenant> neighbors = new List<BlTenant>();
        neighbors = IBlTenant.GetAll(newProposal.Tenant.BuildingCode);
        foreach (BlTenant neighbor in neighbors)
        {
            //send a massage that there is new proposal//
            Console.WriteLine($"Hi {neighbor.FullName}!\n There is a new proposal, \n go to vote and influence!!");
        }
    }


}