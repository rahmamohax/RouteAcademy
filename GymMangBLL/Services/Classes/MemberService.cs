using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.MemberViewModels;
using GymMangBLL.ViewModels.MemberVIewModels;
using GymMangDAL.Entities;
using GymMangDAL.Repositories.Classes;
using GymMangDAL.Repositories.Interfaces;

namespace GymMangBLL.Services.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IEntityRepository<Member> _memberRepository;
        //private readonly IEntityRepository<MemberShip> _membershipRepository;
        //private readonly IPlanRepository _planRepository;
        //private readonly IEntityRepository<HealthRecord> _healthRepository;
        //private readonly IEntityRepository<MemberSession> _memberSessionRepository;

        //Make sure you registered this service before asking clr to inject object
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Helper Methods
        private bool isEmailExists(string email)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(x => x.Email == email).Any();
        }

        private bool isPhoneExists(string phone)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(x => x.Phone == phone).Any();
        }
        #endregion
        public bool CreateMember(CreateMemberViewModel createdMember)
        {
            if (isEmailExists(createdMember.Email) || isPhoneExists(createdMember.Phone)) return false;

            var member = new Member
            {
                Name = createdMember.Name,
                Email = createdMember.Email,
                Phone = createdMember.Phone,
                Gender = createdMember.Gender,
                DateOfBirth = createdMember.DateofBirth,
                Address = new Address
                {
                    BuldingNumber = createdMember.BuildingNumber,
                    City = createdMember.City,
                    Street = createdMember.Street,
                },
                HealthRecord = new HealthRecord
                {
                    Height = createdMember.HealthRecordViewModel.Height,
                    Weight = createdMember.HealthRecordViewModel.Weight,
                    BloodType = createdMember.HealthRecordViewModel.BloodType,
                    Note = createdMember.HealthRecordViewModel.Note
                }
            };
            //return _memberRepository.Add(member) > 0;
             _unitOfWork.GetRepository<Member>().Add(member); //added locally!
            return _unitOfWork.SaveChanges() > 0;

        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _unitOfWork.GetRepository<Member>().GetAll() ?? [];

            var memberView = members.Select(member => new MemberViewModel
            {
                Id = member.Id,
                Photo = member.Photo,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Gender = member.Gender.ToString()
            });
            return memberView;
        }

        public HealthRecordViewModel? GetHealthRecordDetails(int Id)
        {
            var healthRecord = _unitOfWork.GetRepository<HealthRecord>().GetById(Id);
            if (healthRecord is null) return null;
            return new HealthRecordViewModel
            {
                Height = healthRecord.Height,
                Weight = healthRecord.Weight,
                BloodType= healthRecord.BloodType,
                Note = healthRecord.Note
            };
        }

        public MemberViewModel? GetMemberDetails(int Id)
        {
            //var members = _memberRepository.GetAll() ?? [];
            var member = _unitOfWork.GetRepository<Member>().GetById(Id);
            if (member is null) return null;

            var memberView = new MemberViewModel
            {
                Id = member.Id,
                Photo = member.Photo,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Gender = member.Gender.ToString(),
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                MembershipStartDate = member.CreatedAt.ToShortDateString(),
                Address = $"{member.Address.BuldingNumber}-{member.Address.Street}-{member.Address.City}",
               
            };

            var membership = _unitOfWork.GetRepository<MemberShip>().GetAll(x => x.Id == Id && x.Status == "Active")
                .FirstOrDefault();

            if (membership is not null)
            {
                memberView.MembershipStartDate = membership.CreatedAt.ToShortDateString();
                memberView.MembershipEndtDate = membership.EndDate.ToShortDateString();

                var plan = _unitOfWork.GetRepository<Plan>().GetById(membership.PlanId);
                memberView.PlanName = plan?.Name;
            }
            return memberView;
        }

        public UpdateMemberViewModel? GetMemberToUpdate(int Id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(Id);
            if (member is null) return null;

            return new UpdateMemberViewModel
            {
                Email = member.Email,
                Name = member.Name,
                Phone = member.Phone,
                Photo = member.Photo,
                BuildingNumber = member.Address.BuldingNumber,
                Street = member.Address.Street,
                City = member.Address.City,
            };
        }

        public bool UpdateMemberDetails(int Id, UpdateMemberViewModel updateMember)
        {
            try
            {
                if (isEmailExists(updateMember.Email) || isPhoneExists(updateMember.Phone)) return false;

                var member = _unitOfWork.GetRepository<Member>().GetById(Id);
                if (member is null) return false;
                member.Email = updateMember.Email;
                member.Phone = updateMember.Phone;
                member.Address.BuldingNumber = updateMember.BuildingNumber;
                member.Address.Street = updateMember.Street;
                member.Address.City = updateMember.City;
                member.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.GetRepository<Member>().Update(member);
                return _unitOfWork.SaveChanges() > 0;

            }
            catch
            {

                return false;
            }

        }

        public bool RemoveMember(int Id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(Id);
            if (member is null) return false;

            var memberSession = _unitOfWork.GetRepository<MemberSession>()
                .GetAll(x => x.MemberId == Id && x.Session.StartDate > DateTime.Now).Any();
            if (memberSession) return false;  // Can't remove if session is active

            var memberships = _unitOfWork.GetRepository<MemberShip>().GetAll(x => x.MemberId == Id);
            try
            {
                //making sure that this member has no memberships before removing to avoid any exceptions
                if (memberships.Any())
                    foreach (var membership in memberships)
                        _unitOfWork.GetRepository<MemberShip>().Delete(membership);

                 _unitOfWork.GetRepository<Member>().Delete(member);
                return _unitOfWork.SaveChanges() > 0 ;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

