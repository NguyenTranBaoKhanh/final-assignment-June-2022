using Rookie.AssetManagement.Contracts.Dtos.Asset;
using Rookie.AssetManagement.Contracts.Dtos.Assignment;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
        //    CreateMap<User, UserCreateDto>()
        //               .ForMember(d => d.Type, t => t.Ignore());

        //    CreateMap<User, UserDto>()
        //               .ForMember(d => d.Type, t => t.Ignore());
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<User, UserInfoDto>()
                .ReverseMap();

            CreateMap<User, UserCreateDto>()
               .ReverseMap();

            CreateMap<User, UserDto>()
                   .ReverseMap();

            CreateMap<Asset, AssetDto>()
                .ReverseMap();

            CreateMap<Asset, AssetCreateDto>()
                .ReverseMap();

            CreateMap<Asset, AssetUpdateDto>()
                .ReverseMap();

            CreateMap<AssetDto, AssetUpdateDto>()
                .ReverseMap();

            CreateMap<Assignment, AssignmentDto>()
                .ForMember(assignmentDto => assignmentDto.AssetName,
                    options => options.MapFrom(assignment => assignment.Asset.AssetName))
                .ForMember(assignmentDto => assignmentDto.CategoryName, 
                    options => options.MapFrom(assignment => assignment.Asset.Category.CategoryName))
                .ForMember(assignmentDto => assignmentDto.SpecifiCation,
                    options => options.MapFrom(assignment => assignment.Asset.Specification))
                .ReverseMap();

            CreateMap<Assignment, AssignmentCreateDto>()
                .ReverseMap();
        }
    }
}
