namespace BL.BlModels;

public partial class Proposal
{
    public int ProposalId { get; set; }

    public string TenantId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? Voted { get; set; }

    public string? Done { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;
}
