using AutoMapper;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Models;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.ModelView;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<WatercolorsPainting, WatercolorsPaintingView>()
           .ForMember(dest => dest.StyleName, opt => opt.MapFrom(src => src.Style.StyleName));

        }
    }
}
