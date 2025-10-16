using AutoMapper;
using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.MemberViewModels;
using GymMangBLL.ViewModels.MemberVIewModels;
using GymMangDAL.Entities;
using GymMangDAL.Repositories.Classes;
using GymMangDAL.Repositories.Interfaces;

namespace GymMangBLL.Services.Classes
{
    public class MemberService(IUnitOfWork _unitOfWork, IMapper _mapper) : IMemberService
    {
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

            var member = _mapper.Map<Member>(createdMember);

             _unitOfWork.GetRepository<Member>().Add(member); //added locally!
            return _unitOfWork.SaveChanges() > 0;

        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _unitOfWork.GetRepository<Member>().GetAll() ?? [];

            var memberView = _mapper.Map<IEnumerable<MemberViewModel>>(members);
            return memberView;
        }

        public HealthRecordViewModel? GetHealthRecordDetails(int Id)
        {
            var healthRecord = _unitOfWork.GetRepository<HealthRecord>().GetById(Id);
            if (healthRecord is null) return null;
            return _mapper.Map<HealthRecordViewModel>(healthRecord);
        }

        public MemberViewModel? GetMemberDetails(int Id)
        {
            //var members = _memberRepository.GetAll() ?? [];
            var member = _unitOfWork.GetRepository<Member>().GetById(Id);
            if (member is null) return null;

            var memberView = _mapper.Map<MemberViewModel>(member);

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

            return _mapper.Map<UpdateMemberViewModel>(member);
        }

        public bool UpdateMemberDetails(int Id, UpdateMemberViewModel updateMember)
        {
            try
            {
                if (isEmailExists(updateMember.Email) || isPhoneExists(updateMember.Phone)) return false;

                var member = _unitOfWork.GetRepository<Member>().GetById(Id);
                if (member is null) return false;
                
                _mapper.Map(updateMember, member);

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

