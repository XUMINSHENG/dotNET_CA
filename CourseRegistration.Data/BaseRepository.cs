using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;

namespace CourseRegistration.Data
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel  
    {
    }
}
