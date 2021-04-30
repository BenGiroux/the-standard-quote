using AutoMapper;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Web.ApiModels;

namespace ContractorJobBuilderV2.Web.Profiles
{
    public class IndustryProfile : Profile
    {
        public IndustryProfile()
        {
            CreateMap<Industry, IndustryDto>()
                .ForMember(j => j.Title, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Title))
                .ForMember(j => j.Description, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Description))
                .ForMember(j => j.Industry, opt =>
                    opt.MapFrom(src => src.Type.ToString()));
        }
    }
}
