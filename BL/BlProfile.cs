namespace BL;
public class BlProfile:Profile
{
    public BlProfile()
    {
        //המרה לדייר כולל שינוי של שם מלא
        CreateMap<DAL.Models.Tenant, BL.BlModels.BlTenant>().
        ForMember(dest => dest.FullName, source => source.MapFrom(src => src.FirstName + " " + src.LastName));

        //Expenses
        CreateMap<DAL.Models.MonthlyExpense, BL.BlModels.BlMonthlyExpense>();
        CreateMap<DAL.Models.OneTimeExpense, BL.BlModels.BlOneTimeExpense>();

        //Proposal
        CreateMap<BL.BlModels.BlProposal, DAL.Models.Proposal>()
       .ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description))
       .ForMember(dest => dest.TenantId, source => source.MapFrom(src => src.Description))
       .ForMember(dest => dest.Tenant, source => source.MapFrom(src => src.Tenant))
       .ForMember(dest => dest.Voted, source => source.MapFrom(src => src.Voted))
       .ForMember(dest => dest.Done, source => source.MapFrom(src => src.Done));
    }
}
