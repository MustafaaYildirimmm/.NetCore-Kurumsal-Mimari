using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            IsDeleted = false;
            if (Id == 0)
            {
                CreateDate = DateTime.Now;
            }
        }

        [Key]
        public virtual long Id { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime CreateDate { get; set; }

        public virtual long CreateUserId { get; set; }

        public virtual DateTime? UpdateDate { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual byte[] RowVersion { get; set; }

        public virtual void SetPassive()
        {
            UpdateDate = DateTime.Now;
            IsDeleted = true;
        }

        public virtual void SetActive()
        {
            UpdateDate = DateTime.Now;
            IsDeleted = false;
        }

    }
}
