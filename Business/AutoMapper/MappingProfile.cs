using AutoMapper;
using Core.Constants;
using Core.Helpers.Business;
using Core.Helpers.IoC;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        private readonly IAddFileHelperService _addFileHelper;
        public MappingProfile()
        {
            _addFileHelper = ServiceTool.ServiceProvider.GetService<IAddFileHelperService>()!;
            CreateMap<TravelDto, Travel>()
                .ForMember(dest => dest.TravelPicture, opt => opt.MapFrom(src => _addFileHelper.AddFile(src.TravelPicture, FolderNames.ImagesFolder)))
                .ForMember(dest => dest.LocationImgMap, opt => opt.MapFrom(src => _addFileHelper.AddFile(src.LocationImgMap, FolderNames.ImagesFolder)));
        }
    }
}
