namespace BL.BlModels;

public partial class BlProposal
{
    public int ProposalId { get; set; }

    public string TenantId { get; set; } 

    public string Description { get; set; }

    public int? Voted { get; set; } = 0;

    public string? Done { get; set; } = "waiting";

    public virtual BlTenant Tenant { get; set; } = null!;
}
