using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class Rate
    {
        public int Id { get; set; }

        public virtual RatePeriod RatePeriod { get; set; }
        public int RatePeriodId { get; set; }

        public virtual RateType RateType { get; set; }
        public int RateTypeId { get; set; }

        public float Discount { get; set; }

        public float DispensingFee { get; set; }
    }
}