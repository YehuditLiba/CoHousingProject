using DAL.DalApi;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    public class DalProposalService : IProposal
    {
        CoHousingContext _CoHousingData;
        public DalProposalService(CoHousingContext coHousingData)
        {
            _CoHousingData = coHousingData;
        }

        //פונקציה שמקבלת תז דייר ומחזירה את כל ההצעות שהציע
        public List<Proposal> GetProposalsListByTenantId(string id)
        {
            List<Models.Proposal> list = new List<Models.Proposal>();
            foreach (var proposal in _CoHousingData.Proposals)
                if (proposal.TenantId == id) { list.Add(proposal);}
            return list;
        }
        //פונקצייה שמקבלת קוד בנין ומחזירה את כל ההצעות שהוצעו בו
        public List<Proposal> GetProposalsListByBuildingCode(int code)
        {
            List<Proposal> list = new List<Proposal>();
            list = _CoHousingData.Proposals.Include(p => p.Tenant).Where(p => p.Tenant.BuildingCode == code).ToList();
            return list;
        }
        public Proposal GetProposalById(int id)
        {
            var proposal = _CoHousingData.Proposals.FirstOrDefault(p=>p.ProposalId==id);
            if (proposal == null) { return null; }
            return proposal;
        }
        public Proposal AddProposal(Proposal proposal)
        {
            _CoHousingData.Proposals.Add(proposal);
            _CoHousingData.SaveChanges();
            return proposal;
        }
        public Proposal RemoveProposal(int id)
        {
            var proposal = _CoHousingData.Proposals.FirstOrDefault(p => p.ProposalId == id);
            if (proposal == null) { return null; }
            _CoHousingData.Proposals.Remove(proposal);
            _CoHousingData.SaveChanges();
            return proposal;
        }
        public Proposal UpdateProposal(Proposal newProposal,string id)
        {
            var oldProposal = _CoHousingData.Proposals.FirstOrDefault(p => p.TenantId == id);
            if (oldProposal == null)
                return null;
            oldProposal.ProposalId = newProposal.ProposalId;
            oldProposal.Description = newProposal.Description;
            oldProposal.TenantId = newProposal.TenantId;
            _CoHousingData.SaveChanges();
            return newProposal;
        }
    }
}
