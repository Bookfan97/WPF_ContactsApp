using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ContactsApps.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int contactID { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhone { get; set; }
    }
}
