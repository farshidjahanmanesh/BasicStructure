using System;
using System.Collections.Generic;
using System.Text;

namespace Loan.Framework.Commons.Entities
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifedBy { get; set; }
        public DateTime? LastModifedDate { get; set; }
    }
}
