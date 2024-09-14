using AutoMapper;
using Core.Constants;
using Core.Helpers.Business;
using Core.Helpers.IoC;
using Entities.Concrete;
using Entities.Dto;
using Entities.Dto.CategoryDtos;
using Entities.DTO.TravelDTOs;
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

            CreateMap<Travel, TravelDetailDto>();

            CreateMap<AboutDto, About>()
                .ForMember(dest => dest.ProfilePciture, opt => opt.MapFrom(src => _addFileHelper.AddFile(src.ProfilePciture, FolderNames.ImagesFolder)));

            CreateMap<AddCategoryDto, Category>()
                .ForMember(dest => dest.CategoryImg, opt => opt.MapFrom(src => _addFileHelper.AddFile(src.CategoryImg, FolderNames.ImagesFolder)));

            CreateMap<FAQDto, FAQ>();
        }
    }
}
