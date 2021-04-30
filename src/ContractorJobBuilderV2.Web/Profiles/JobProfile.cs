using AutoMapper;
using ContractorJobBuilderV2.Core.Aggregates;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.Web.ApiModels;
using System.Linq;

namespace ContractorJobBuilderV2.Web.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDto>()
                .ForMember(j => j.Id, opt =>
                    opt.MapFrom(src => src.Id.Id))
                .ForMember(j => j.Title, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Title))
                .ForMember(j => j.Description, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Description))
                .ForMember(j => j.JobTasks, opt =>
                    opt.MapFrom(src => src.JobTasks.OrderBy(jt => jt.Order)));

            CreateMap<JobForCreationDto, Job>().ReverseMap()
                .ForMember(j => j.Title, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Title))
                .ForMember(j => j.Description, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Description))
                .ForMember(j => j.JobTasks, opt =>
                    opt.MapFrom(src => src.JobTasks));

            CreateMap<JobForUpdateDto, Job>().ReverseMap()
                .ForMember(j => j.Title, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Title))
                .ForMember(j => j.Description, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Description))
                .ForMember(j => j.JobTasks, opt =>
                    opt.MapFrom(src => src.JobTasks));

            CreateMap<JobTaskForCreationDto, JobTask>().ReverseMap()
                .ForMember(j => j.Title, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Title))
                .ForMember(j => j.Description, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Description))
                .ForMember(j => j.Order, opt =>
                    opt.MapFrom(src => src.Order))
                .ForMember(j => j.JobTaskItems, opt =>
                    opt.MapFrom(src => src.JobTaskItems));

            CreateMap<JobTaskForUpdateDto, JobTask>().ReverseMap()
                .ForMember(j => j.Title, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Title))
                .ForMember(j => j.Description, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Description))
                .ForMember(j => j.Order, opt =>
                    opt.MapFrom(src => src.Order))
                .ForMember(j => j.JobTaskItems, opt =>
                    opt.MapFrom(src => src.JobTaskItems));

            CreateMap<JobTaskItemForCreationDto, JobTaskItem>()
                .ForMember(j => j.Summary, opt =>
                        opt.MapFrom(src => src.Summary));

            CreateMap<JobTaskItemForUpdateDto, JobTaskItem>()
                .ForMember(j => j.Summary, opt =>
                        opt.MapFrom(src => src.Summary));

            CreateMap<JobTask, JobTaskDto>()
                .ForMember(j => j.Id, opt =>
                    opt.MapFrom(src => src.Id.Id))
                .ForMember(j => j.Title, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Title))
                .ForMember(j => j.Description, opt =>
                    opt.MapFrom(src => src.TitleAndDescription.Description))
                .ForMember(j => j.JobTaskItems, opt =>
                    opt.MapFrom(src => src.JobTaskItems));
        }
    }
}
