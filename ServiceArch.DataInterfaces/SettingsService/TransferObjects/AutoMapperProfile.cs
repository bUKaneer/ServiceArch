using AutoMapper;
using ServiceArch.DataInterfaces.SettingService.Entities;

namespace ServiceArch.DataInterfaces.SettingService.TransferObjects
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Setting, SettingDto>();
        }
    }
}
