using AutoMapper;
using GymManagementSystemBLL.ViewModels.SessionViewModels;
using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.SessionViewModels;
using GymMangDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Classes
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        #region Helper
        private bool canSessionBeUpdated(Session session)
        {
            if (session == null) return false;
            //if session is completed -> no updates allowed
            if (session.EndDate <  DateTime.UtcNow) return false;

            //if session has started -> no updates allowed
            if (session.StartDate <= DateTime.UtcNow) return false;

            //if session is active -> no updates allowed
            var activeBookings = _unitOfWork.SessionRepository.coutOfBookedSlots(session.Id) > 0;
            if (activeBookings) return false;

            return true;

        }
        private bool canSessionBeDeleted(Session session)
        {
            if (session == null) return false;

            //if session has ongoing -> no deletion allowed
            if (session.StartDate <= DateTime.UtcNow && session.EndDate > DateTime.Now) return false;

            //if session is upcoming -> no deletion allowed
            if (session.StartDate > DateTime.UtcNow) return false;


            //if session is active -> no deletion allowed
            var activeBookings = _unitOfWork.SessionRepository.coutOfBookedSlots(session.Id) > 0;
            if (activeBookings) return false;

            return true;

        }
        private bool DoesTrainerExists(int id)
        {
            return _unitOfWork.GetRepository<Trainer>().GetAll(x => x.Id == id).Any();
        }
        private bool DoesCategoryExists(int id)
        {
            return _unitOfWork.GetRepository<Category>().GetById(id) is not null;
        }        
        private bool isDateTimeValid(DateTime start, DateTime end)
        {
            return (start < end) && DateTime.Now < start;
        }
        #endregion

        public bool CreateSession(CreateSessionViewModel createSession)
        {
            try
            {
                if (createSession == null) throw new ArgumentNullException();

                if (!DoesTrainerExists(createSession.TrainerId)) return false;

                if (!DoesCategoryExists(createSession.CategoryId)) return false;

                if (!isDateTimeValid(createSession.StartDate, createSession.EndDate)) return false;

                if (createSession.Capacity > 25 || createSession.Capacity < 0) return false;

                var mappedSession = _mapper.Map<Session>(createSession);

                _unitOfWork.SessionRepository.Add(mappedSession);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Creating Session Failed : " + ex);
                return false;
            }

        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var sessions = _unitOfWork.SessionRepository.GetAllSessionsWithRelations();
            if (sessions == null) return Enumerable.Empty<SessionViewModel>();

            //return sessions.Select(session => new SessionViewModel()
            //{
            //    Id = session.Id,
            //    TrainerName = session.Trainer.Name,             //Related Data, Not loaded by default
            //    CategoryName = session.Category.CategoryName,   //Related Data, Not loaded by default
            //    Description = session.Description,
            //    StartDate = session.StartDate,
            //    EndDate = session.EndDate,
            //    Capacity = session.Capacity,
            //    AvailableSlots = session.Capacity - _unitOfWork.SessionRepository.coutOfBookedSlots(session.Id) // Computed (capacity - count of booking per session)           
            //});

            var mappedSessions= _mapper.Map<IEnumerable<Session> ,IEnumerable<SessionViewModel>>(sessions);
            foreach (var item in mappedSessions)
                item.AvailableSlots = item.Capacity - _unitOfWork.SessionRepository.coutOfBookedSlots(item.Id);
            return mappedSessions;
        }

        public SessionViewModel? GetSessionById(int id)
        {
            var session = _unitOfWork.SessionRepository.GetSessionWithRelations(id);
            if (session == null) return null;
            
            var mappedSession= _mapper.Map<SessionViewModel>(session);
            mappedSession.AvailableSlots = mappedSession.Capacity - _unitOfWork.SessionRepository.coutOfBookedSlots(id);
            return mappedSession;
        }

        public UpdateSessionViewModel GetSessionToUpdate(int sessionId)
        {
            var session = _unitOfWork.SessionRepository.GetById(sessionId);
            if (!canSessionBeUpdated(session!)) return null!;

            return _mapper.Map<UpdateSessionViewModel>(session);
        }

        public bool UpdateSession(int sessionId, UpdateSessionViewModel updateSession)
        {
            try
            {
                var session = _unitOfWork.SessionRepository.GetSessionWithRelations(sessionId);
                if(!canSessionBeUpdated(session!)) return false;
                if (!DoesTrainerExists(session!.TrainerId)) return false;
                if(!isDateTimeValid(session.StartDate, session.EndDate)) return false;

                _mapper.Map(updateSession, session);
                session.UpdatedAt = DateTime.Now;

                _unitOfWork.SessionRepository.Update(session);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Failed : " + ex);
                throw;
            }
        }

        public bool DeleteSession(int sessionId)
        {
            try
            {
                var session = _unitOfWork.SessionRepository.GetById(sessionId);
                if (!canSessionBeDeleted(session!)) return false;

                _unitOfWork.SessionRepository.Delete(session!);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TrainerSelectViewModel> GetTrainers()
        {
            var trainers = _unitOfWork.GetRepository<Trainer>().GetAll();
            if (trainers is null) return Enumerable.Empty<TrainerSelectViewModel>();

            return trainers.Select(x => new TrainerSelectViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            });
        }

        public IEnumerable<CategorySelectViewModel> GetCategories()
        {
            var categories = _unitOfWork.GetRepository<Category>().GetAll();
            if (categories is null) return Enumerable.Empty<CategorySelectViewModel>();

            return categories.Select(x => new CategorySelectViewModel()
            {
                Id = x.Id,
                Name = x.CategoryName
            }); 
        }
    }
}
