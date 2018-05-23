using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public abstract class LocationContact
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public virtual State State { get; set; }
        public int StateId { get; set; }

        public string ZipCode { get; set; }

        public int PhoneNumber { get; set; }

        public int FaxNumber { get; set; }
    }
}