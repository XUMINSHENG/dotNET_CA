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
            using(IUnitOfWork uow = new UnitOfWork()){
                uow.ParticipantRepository.Insert(p);
                uow.Save();
            }
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            using(IUnitOfWork uow = new UnitOfWork())
            {
                return uow.ParticipantRepository.GetAll().ToList();
            }
        }

        public Participant GetParticipantById(int id)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                return uow.ParticipantRepository.GetById(id);
            }
        }

        public void EditParticipant(Participant p)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                uow.ParticipantRepository.Edit(p);
                uow.Save();
            }
        }

        public void DeleteParticipant(Participant p)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                uow.ParticipantRepository.Delete(p);
                uow.Save();
            }
        }
    }
}
