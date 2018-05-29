using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class ContractInfo
    {
        public int Id { get; set; }

        public virtual Client Client { get; set; }
        public int ClientId { get; set; }

        public DateTime ContractEffectiveDate { get; set; }

        public int BenefitRenewalMonth { get; set; }

        public int ContractLength { get; set; }

        public bool GrandfatherStatus { get; set; }

        public bool ERISAStatus { get; set; }

        public bool TaxExempt { get; set; }

        public virtual PricingType PricingType { get; set; }
        public int PricingTypeId { get; set; }

        public virtual ICollection<ContractFormularyJunction> Formularies { get; set; }

        public virtual ICollection<ContractProgramJunction> Programs { get; set; }
    }
}