using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class ClientContactPerson:PersonContact
    {
        public int Id { get; set; }

        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
    }
}