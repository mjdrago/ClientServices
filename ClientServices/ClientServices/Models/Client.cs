using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime OriginalEffectiveDate { get; set; }

        public DateTime TerminationDate { get; set; }

        public bool RunOutNeeded { get; set; }

        public DateTime RunOutDate { get; set; }

        public bool ImproperTerminationNotice { get; set; }

        public virtual TermReason TermReason { get; set; }
        public int TermReasonId { get; set; }

        public bool ClosedClientIndicator { get; set; }
    }
}