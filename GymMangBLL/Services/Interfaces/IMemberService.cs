using GymMangBLL.ViewModels.MemberViewModels;

namespace GymMangBLL.Services.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetAllMembers();
        bool CreateMember(CreateMemberViewModel createdMember);
        MemberViewModel? GetMemberDetails(int Id);
        HealthRecordViewModel? GetHealthRecordDetails(int Id);
        UpdateMemberViewModel? GetMemberToUpdate(int Id);
        bool UpdateMemberDetails(int Id, UpdateMemberViewModel updateMemberDetails);
        bool RemoveMember(int Id);
    }
}
