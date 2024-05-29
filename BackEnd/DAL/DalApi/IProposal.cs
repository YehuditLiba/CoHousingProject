using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IProposal
    {
        public List<Proposal> GetProposalsListByTenantId(string id);
        public List<Proposal> GetProposalsListByBuildingCode(int code);
        public Proposal GetProposalById(int id);
        public Proposal AddProposal(Proposal proposal);
        public Proposal RemoveProposal(int id);
        public Proposal UpdateProposal(Proposal newProposal, string id);
    }
}
