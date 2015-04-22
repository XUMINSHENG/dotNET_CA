using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class BaseModel
    {
        
        #region Constructor

        protected BaseModel()
        {
            IsDeleted = false;
            AddDate = DateTime.Now;
        }

        #endregion

        #region Attribute

        /// <summary>
        ///     logically deletion
        /// </summary>
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddDate { get; set; }

        /// <summary>
        ///     data consistency control
        /// </summary>
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        #endregion
        
    }
}
