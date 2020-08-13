using System.Text.RegularExpressions;

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
                && EmailMessage.Length <= 1024)
            {
                if (Regex.Matches(EmailAddress, "([a-zA-Z0-9+._-]+@[a-zA-Z0-9._-]+.[a-zA-Z0-9_-]+)").Count == 1)
                {
                    if (BranchCode != null
                        && IncidentCode.Length > 0)
                    {
                        if (BranchCode.Length == 9 && Regex.Matches(BranchCode, "([0-9]{2}-[0-9]{3}-[0-9]{2})").Count == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
    }

}