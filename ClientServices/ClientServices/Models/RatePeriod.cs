using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class RatePeriod
    {
        public int Id { get; set; }

        public virtual ContractInfo Contract { get; set; }
        public int ContractInfoId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime TerminationDate { get; set; }
    }
}