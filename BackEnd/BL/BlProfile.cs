
namespace BL
{
    public class BlProfile:Profile
    {
        public BlProfile()
        {

            //המרה לדייר כולל שינוי של שם מלא
            CreateMap<DAL.Models.Tenant, BL.BlModels.Tenant>().
            ForMember(dest => dest.FullName, source => source.MapFrom(src => src.FirstName + " " + src.LastName));
            //המרה בהוצאות חודשיות ללא שינוי בפרמטר מסויים
            CreateMap<DAL.Models.MonthlyExpense, BL.BlModels.MonthlyExpense>();
            CreateMap<DAL.Models.OneTimeExpense, BL.BlModels.OneTimeExpense>(); 
        }

}
    //public BlProfile() => CreateMap<Tenant, TenantDTO>();
    
    //public class BlProfile : Profile
    //{
    //    public BlProfile()
    //    {
    //        CreateMap<>
    //    }
    //    // public BlProfile() => CreateMap<Tenant, TenantDTO>();
    //}
}
