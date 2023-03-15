using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CleanArchitecture.Domain.Shared
{
    public abstract class BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public Boolean? isDeleted { get; set; }
    }
}

