using System;
using System.Collections.Generic;
using System.Text;

namespace ELM__AM
{
    public class Email
    {
        public string ID { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string EmailMessage { get; set; }
        public string BranchCode { get; set; }
        public string IncidentCode { get; set; }

        public Email()
        {

        }

        public bool Validation()
        {
            if (EmailAddress.Length > 0
                && Subject.Length > 0
                && EmailMessage.Length > 0
                && EmailMessage.Length <= 1024) { 
                if (BranchCode.Length > 0
                    && IncidentCode.Length > 0)
                {
                    return true;
                }
                return true;
            }
            return false;
        }
    }

}