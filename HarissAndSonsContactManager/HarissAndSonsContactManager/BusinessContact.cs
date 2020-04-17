using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarissAndSonsContactManager
{
    /// <summary>
    /// This class inherits from Contact.cs class 
    /// and contains the BusinessTel property.
    /// The class is used by BusinessEditor.cs class
    /// </summary>
    public class BusinessContact : Contact
    {
        // BusinessTel property //
        public string BusinessTel { get; set; }
    }
}
