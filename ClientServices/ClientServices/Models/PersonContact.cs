using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientServices.Models
{
    public abstract class PersonContact
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public int Extension { get; set; }

        public virtual ContactType ContactType { get; set; }
        public int ContactTypeId { get; set; }

        public virtual Position Position { get; set; }
        public int PositionId { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}