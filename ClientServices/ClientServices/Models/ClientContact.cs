using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class ClientContact:LocationContact
    {
        public int Id { get; set; }

        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
    }
}