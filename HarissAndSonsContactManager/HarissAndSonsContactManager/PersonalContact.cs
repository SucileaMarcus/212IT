using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarissAndSonsContactManager
{
    /// <summary>
    /// This class inherits from Contact.cs class 
    /// and contains the PersonalTel property.
    /// The class is used by PersonalEditor.cs class
    /// </summary>
    public class PersonalContact : Contact
    {
        public string PersonalTel { get; set; }

    }
}
