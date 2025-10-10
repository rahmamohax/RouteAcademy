using AutoMapper;
using GymManagementSystemBLL.ViewModels.SessionViewModels;
using GymMangBLL.ViewModels.SessionViewModels;
using GymMangDAL.Entities;

namespace GymMangBLL
{
    public class Mappingprofiles : Profile
    {
        public Mappingprofiles()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.CategoryName, option => option.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.TrainerName, option => option.MapFrom(src => src.Trainer.Name))
                .ForMember(dest => dest.AvailableSlots, option => option.Ignore());

            CreateMap<CreateSessionViewModel, Session>();
            CreateMap<UpdateSessionViewModel, Session>().ReverseMap();

        }
    }
}
