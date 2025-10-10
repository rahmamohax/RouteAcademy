using GymMangBLL.ViewModels.TrainerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();
        bool CreateTrainer(CreateTrainerViewModel createTrainer);
        TrainerViewModel? GetTrainerDetails(int  id);
        UpdateTrainerViewModel? TrainerToUpdate(int id);
        bool UpdateTrainerDetails(int id, UpdateTrainerViewModel updateTrainerDetails);
        bool DeleteTrainer(int id);
    }
}
