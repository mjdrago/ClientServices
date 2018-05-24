using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class ClientVendorJunction
    {
        public int Id { get; set; }

        public virtual Client Client { get; set; }
        public int ClientId { get; set; }

        public virtual Vendor Vendor { get; set; }
        public int VendorId { get; set; }

        public virtual ClientVendorRelationship ClientVendorRelationship { get; set; }
        public int ClientVendorRelationshipId { get; set; }
    }
}