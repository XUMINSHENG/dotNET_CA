using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistration.Data
{
    public interface IUnitOfWork
    {
        #region Attribute

        bool IsCommitted { get; }

        #endregion

        #region Method

        int Commit();

        void Rollback();

        #endregion
    }
}
