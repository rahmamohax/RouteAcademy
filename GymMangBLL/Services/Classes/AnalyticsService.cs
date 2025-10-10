using GymManagementSystemBLL.ViewModels.AnalyticsViewModels;
using GymMangBLL.Services.Interfaces;
using GymMangDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Classes
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AnalyticsViewModel GetAnalytics()
        {
            var sessions = _unitOfWork.SessionRepository.GetAll();
            return new AnalyticsViewModel
            {
                ActiveMembers = _unitOfWork.GetRepository<MemberShip>().GetAll(x => x.Status == "Active").Count(),
                TotalMembers = _unitOfWork.GetRepository<Member>().GetAll().Count(),
                TotalTrainers = _unitOfWork.GetRepository<Trainer>().GetAll().Count(),
                UpcomingSessions = sessions.Count(x => x.StartDate > DateTime.Now),
                OngoingSessions = sessions.Count(x => x.StartDate <= DateTime.Now && x.EndDate > DateTime.Now),
                CompletedSessions = sessions.Count(x => x.EndDate < DateTime.Now),
            };
        }
    }
}
