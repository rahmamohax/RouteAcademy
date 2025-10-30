using GymManagementSystemBLL.ViewModels.SessionViewModels;
using GymMangBLL.ViewModels.SessionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Interfaces
{
    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessions();
        SessionViewModel? GetSessionById(int id);
        bool CreateSession(CreateSessionViewModel createSession);
        UpdateSessionViewModel GetSessionToUpdate(int sessionId);
        bool UpdateSession(int sessionId, UpdateSessionViewModel updateSession);
        bool DeleteSession(int sessionId);
        IEnumerable<TrainerSelectViewModel> GetTrainers();
        IEnumerable<CategorySelectViewModel> GetCategories();

    }
}
