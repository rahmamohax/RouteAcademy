using AutoMapper;
using GymManagementSystemBLL.ViewModels.SessionViewModels;
using GymMangBLL.ViewModels.MemberViewModels;
using GymMangBLL.ViewModels.PlanViewModels;
using GymMangBLL.ViewModels.SessionViewModels;
using GymMangBLL.ViewModels.TrainerViewModels;
using GymMangDAL.Entities;
//using Member = GymMangDAL.Entities.Member;

namespace GymMangBLL
{
    public class Mappingprofiles : Profile
    {
        public Mappingprofiles()
        {
            MapSession();

            MapMember();

            MapTrainer();

            MapPlan();
        }
        private void MapSession()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.CategoryName, option => option.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.TrainerName, option => option.MapFrom(src => src.Trainer.Name))
                .ForMember(dest => dest.AvailableSlots, option => option.Ignore());

            CreateMap<CreateSessionViewModel, Session>();
            CreateMap<UpdateSessionViewModel, Session>().ReverseMap();
        }
        private void MapMember()
        {
            CreateMap<CreateMemberViewModel, Member>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address()
                {
                    BuildingNumber = src.BuildingNumber,
                    City = src.City,
                    Street = src.Street,
                }))
                .ForMember(d => d.HealthRecord, opt => opt.MapFrom(s => s.HealthRecordViewModel));

            CreateMap<HealthRecordViewModel, HealthRecord>().ReverseMap();

            CreateMap<Member, MemberViewModel>()
                .ForMember(d=>d.Gender, opt => opt.MapFrom(s => s.Gender.ToString()))
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.DateOfBirth.ToShortDateString()))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => $"{s.Address.BuildingNumber}-{s.Address.Street}-{s.Address.City}"));

            CreateMap<Member, UpdateMemberViewModel>()
                .ForMember(d => d.BuildingNumber, opt => opt.MapFrom(s => s.Address.BuildingNumber))
                .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Address.Street))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.Address.City));

            CreateMap<UpdateMemberViewModel, Member>()
                .ForMember(d => d.Name, opt => opt.Ignore())
                .ForMember(d => d.Photo, opt => opt.Ignore())
                .AfterMap((src,dest) =>
                {
                    dest.Address.BuildingNumber = src.BuildingNumber;
                    dest.Address.Street = src.Street;
                    dest.Address.City = src.City;
                    dest.UpdatedAt = DateTime.Now;
                });
        }
        private void MapTrainer()
        {
            CreateMap<CreateTrainerViewModel, Trainer>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    BuildingNumber = src.BuildingNumber,
                    Street = src.Street,
                    City = src.City
                }));

            CreateMap<Trainer, TrainerViewModel>()
                .ForMember(dist => dist.Specialization, opt => opt.MapFrom(src => src.Specialties.ToString()))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => $"{s.Address.BuildingNumber}-{s.Address.Street}-{s.Address.City}")); ;

            CreateMap<Trainer, UpdateTrainerViewModel>()
                .ForMember(dist => dist.Specialty, opt => opt.MapFrom(src => src.Specialties))
                .ForMember(dist => dist.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dist => dist.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dist => dist.BuildingNumber, opt => opt.MapFrom(src => src.Address.BuildingNumber));

            CreateMap<UpdateTrainerViewModel, Trainer>()
            .ForMember(dest => dest.Name, opt => opt.Ignore())
            .ForMember(dist => dist.Specialties, opt => opt.MapFrom(src => src.Specialty))
            .AfterMap((src, dest) =>
            {
                dest.Address.BuildingNumber = src.BuildingNumber;
                dest.Address.City = src.City;
                dest.Address.Street = src.Street;
                dest.UpdatedAt = DateTime.Now;
            });
        }
        private void MapPlan()
        {
            CreateMap<Plan, PlanViewModel>();
            CreateMap<Plan, UpdatePlanViewModel>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.DurationDays));

            CreateMap<UpdatePlanViewModel, Plan>()
                .ForMember(dest => dest.DurationDays, opt => opt.MapFrom(src => src.Duration))
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
        }

    }
}
