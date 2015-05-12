using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class ParticipantBLL
    {
    private static readonly Lazy<ParticipantBLL> lazy =
            new Lazy<ParticipantBLL>(() => new ParticipantBLL());
      
        public static ParticipantBLL Instance { get { return lazy.Value; } }

        private ParticipantBLL()
        {
        }

        public void CreateParticipant(Participant p)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.ParticipantRepository.Insert(p);
            uow.Save();
        }

        public List<Participant> GetAllParticipants()
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.ParticipantRepository.GetAll().ToList();
            
        }

        public Participant GetParticipantById(int id)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            return uow.ParticipantRepository.GetById(id);
            
        }

        public void EditParticipant(Participant p)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.ParticipantRepository.Edit(p);
            uow.Save();
            
        }

        public void DeleteParticipant(Participant p)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.ParticipantRepository.Delete(p);
            uow.Save();
            
        }
    }
}
