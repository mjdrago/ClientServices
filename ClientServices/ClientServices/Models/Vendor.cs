using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public class Vendor:LocationContact
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}