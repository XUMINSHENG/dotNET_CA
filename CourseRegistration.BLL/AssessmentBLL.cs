using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class AssessmentBLL
    {

        private static readonly Lazy<AssessmentBLL> lazy =
            new Lazy<AssessmentBLL>(() => new AssessmentBLL());

        public static AssessmentBLL Instance { get { return lazy.Value; } }

        private AssessmentBLL()
        {

        }

        public void CreateAssessment(Assessment assessment)
        {
            IUnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();
            uow.AssessmentRepository.Insert(assessment);
            uow.Save();
        }
    }
}
