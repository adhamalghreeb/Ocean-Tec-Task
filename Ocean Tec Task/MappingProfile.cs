using AutoMapper;
using Ocean_Tec_Task.Models;
using Ocean_Tec_Task.Shared;

namespace Ocean_Tec_Task
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Unit, UnitDto>();
            CreateMap<UnitDto, Unit>();

            CreateMap<Characteristics, CharacteristicsDto>();
            CreateMap<CharacteristicsDto, Characteristics>();
        }
    }
}
