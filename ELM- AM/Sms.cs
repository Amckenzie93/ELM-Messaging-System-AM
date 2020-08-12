using System;
using System.Collections.Generic;
using System.Text;

namespace ELM__AM
{
    public class Sms
    {
        public string ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Textmessage { get; set; }

        public Sms()
        {

        }

        public bool Validation()
        {
            if(Textmessage.Length > 0 && PhoneNumber.Length >= 7 && PhoneNumber.Length <= 15 && ElmUtilities.IsNumber(PhoneNumber))
            {
                return true;
            }
            return false;
        }
    }
}
