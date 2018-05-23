using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class VendorContactPerson:PersonContact
    {
        public int Id { get; set; }

        public virtual Vendor Vendor { get; set; }
        public int VendorId { get; set; }
    }
}