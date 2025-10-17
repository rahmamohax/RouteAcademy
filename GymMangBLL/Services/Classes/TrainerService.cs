using AutoMapper;
using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.TrainerViewModels;
using GymMangDAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Classes
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Helper
        private bool emailExists(string email)
        {
            var doesExists = _unitOfWork.GetRepository<Trainer>().GetAll(t => t.Email == email).Any();
            return doesExists;
        }
        private bool phoneExists(string phone)
        {
            var doesExists = _unitOfWork.GetRepository<Trainer>().GetAll(t => t.Phone == phone).Any();
            return doesExists;
        }
        #endregion

        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var trainers = _unitOfWork.GetRepository<Trainer>().GetAll() ?? [];

            return _mapper.Map<IEnumerable<TrainerViewModel>>(trainers);
                
        }

        public bool CreateTrainer(CreateTrainerViewModel createTrainer)
        {
            if (emailExists(createTrainer.Email) || phoneExists(createTrainer.Phone)) return false;

            var trainer = _mapper.Map<Trainer>(createTrainer);

            try
            {
                _unitOfWork.GetRepository<Trainer>().Add(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TrainerViewModel? GetTrainerDetails(int id)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(id);
            if (trainer == null) return null;

            return _mapper.Map<TrainerViewModel>(trainer);
        }

        public UpdateTrainerViewModel? TrainerToUpdate(int id)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(id);
            if (trainer == null) return null;

            return _mapper.Map<UpdateTrainerViewModel>(trainer);
        }

        public bool UpdateTrainerDetails(int id, UpdateTrainerViewModel updateTrainerDetails)
        {
            var repo = _unitOfWork.GetRepository<Trainer>();
            var trainer = repo.GetById(id);

            var emailExit = repo.GetAll(x => x.Email == updateTrainerDetails.Email && x.Id != id).Any();
            var phoneExit = repo.GetAll(x => x.Phone == updateTrainerDetails.Phone && x.Id != id).Any();
            if (emailExit|| phoneExit || trainer is null) return false;

            _mapper.Map(updateTrainerDetails, trainer);

            try
            {
                repo.Update(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTrainer(int id)
        {
            var repo = _unitOfWork.GetRepository<Trainer>();
            var trainer = repo.GetById(id);
            var haveSessions= _unitOfWork.GetRepository<Session>().GetAll(s => s.TrainerId == id).Any();

            if (haveSessions || trainer is null) return false;

            try
            {
                repo.Delete(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch
            {
                return false;
                
            }
        }
    }
}
