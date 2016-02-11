using AutoMapper;
using ServiceArch.DataInterfaces.TaskListService.Entities;

namespace ServiceArch.DataInterfaces.TaskListService.TransferObjects
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<TaskList, TaskListDto>();
            CreateMap<Task, TaskDto>();
        }
    }
}
