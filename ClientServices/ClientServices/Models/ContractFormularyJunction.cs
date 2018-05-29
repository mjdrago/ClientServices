using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class ContractFormularyJunction
    {
        public int Id { get; set; }

        public virtual ContractInfo Contract { get; set; }
        public int ContractInfoId { get; set; }

        public virtual FormularyType Formulary { get; set; }
        public int FormularyTypeId { get; set; }
    }
}