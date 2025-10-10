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

        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            return trainers.Select(x => new TrainerViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Specialization = x.Specialties.ToString(),
            });
        }

        public bool CreateTrainer(CreateTrainerViewModel createTrainer)
        {
            if (emailExists(createTrainer.Email) || phoneExists(createTrainer.Phone)) return false;

            var trainer = new Trainer()
            {
                Name = createTrainer.Name,
                Email = createTrainer.Email,
                Phone = createTrainer.Phone,
                Address = new Address
                {
                    BuldingNumber = createTrainer.BuildingNumber,
                    City = createTrainer.City,
                    Street = createTrainer.Street,
                },
                Gender = createTrainer.Gender,
                Specialties = createTrainer.Specialty,
                CreatedAt = createTrainer.HireDate,
                DateOfBirth = createTrainer.DateofBirth               
            };

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

            return new TrainerViewModel
            {
                Name = trainer.Name,
                Specialization = trainer.Specialties.ToString(),
                Email = trainer.Email,
                Phone = trainer.Phone,
                DateOfBirth = trainer.DateOfBirth.ToShortDateString(),
                Address = $"{trainer.Address.BuldingNumber}-{trainer.Address.Street}-{trainer.Address.City}"
            };
        }

        public UpdateTrainerViewModel? TrainerToUpdate(int id)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(id);
            if (trainer == null) return null;

            return new UpdateTrainerViewModel
            {
                Email = trainer.Email,
                Phone = trainer.Phone,
                BuildingNumber = trainer.Address.BuldingNumber,
                City = trainer.Address.City,
                Street = trainer.Address.Street,
                Specialty = trainer.Specialties
            };
        }

        public bool UpdateTrainerDetails(int id, UpdateTrainerViewModel updateTrainerDetails)
        {
            var repo = _unitOfWork.GetRepository<Trainer>();
            var trainer = repo.GetById(id);
            if (emailExists(updateTrainerDetails.Email) || phoneExists(updateTrainerDetails.Phone) || trainer is null) return false;

            trainer.Email = updateTrainerDetails.Email;
            trainer.Phone = updateTrainerDetails.Phone;
            trainer.Address.BuldingNumber = updateTrainerDetails.BuildingNumber;
            trainer.Address.City = updateTrainerDetails.City;
            trainer.Address.Street = updateTrainerDetails.Street;
            trainer.Specialties = updateTrainerDetails.Specialty;
            trainer.UpdatedAt = DateTime.Now;

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
