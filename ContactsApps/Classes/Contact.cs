using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApps.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int contactID { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhone { get; set; }

        public override string ToString()
        {
            return $"{contactName} - {contactEmail} - {contactPhone}";
        }
    }
}
