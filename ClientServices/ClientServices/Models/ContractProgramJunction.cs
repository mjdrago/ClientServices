using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class ContractProgramJunction
    {
        public int Id { get; set; }

        public virtual ContractInfo Contract { get; set; }
        public int ContractInfoId { get; set; }

        public virtual ProgramType Program { get; set; }
        public int ProgramTypeId { get; set; }
    }
}