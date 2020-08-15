using System;
using System.Text.RegularExpressions;

namespace ELM__AM
{
    public class Email
    {
        private string _id;
        private string _emailAddress;
        private string _subject;
        private string _emailMessage;
        private string _branchCode;
        private string _incidentCode;


        public Email(string id, string messageBody, DataCollection data)
        {
            ID = id;
            var body = messageBody.Split(',');
            if (body.Length == 3)
            {
                Subject = body[0];
                EmailAddress = body[1];
                EmailMessage = LinkCheck(ElmUtilities.WordAbreviations(body[2]), data);
            }
            else if (body.Length == 5)
            {
                Subject = body[0];
                EmailAddress = body[1];
                EmailMessage = body[2];
                BranchCode = body[3];
                IncidentCode = body[4];
            }
            else
            {
                throw new Exception("Please enter all Email details.");
            }
        }


        public Email(string id, string subject, string emailAddress, string emailMessage, DataCollection data)
        {
            ID = id;
            Subject = subject;
            EmailAddress = emailAddress;
            EmailMessage = LinkCheck(ElmUtilities.WordAbreviations(emailMessage), data);
        }


        public Email(string id, string subject, string emailAddress, string emailMessage, string branchCode, string incidentCode, DataCollection data)
        {
            ID = id;
            Subject = subject;
            EmailAddress = emailAddress;
            EmailMessage = LinkCheck(ElmUtilities.WordAbreviations(emailMessage), data);
            BranchCode = branchCode;
            IncidentCode = incidentCode;
        }

        public string LinkCheck(string val, DataCollection data)
        {
            string regex = @"((http|www|https|ftp):\/\/)?[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?";
            MatchCollection replaced = Regex.Matches(val, regex);
            foreach (var item in replaced)
            {
                data.quarantinedList.Add(item.ToString());
                val = Regex.Replace(val, regex, "<URL Quarantined>");
            }
            return val;
        }


        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value.Length == 10)
                {
                    _id = value;
                }
                else
                {
                    throw new Exception("Message header ID must be 10 characters long.");
                }
            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 20)
                {
                    _subject = value;
                }
                else
                {
                    throw new Exception("Your subject needs to be between 1 and 20 characters long");
                }
            }
        }


        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                if (value.Length > 0 && Regex.Matches(value, "([a-zA-Z0-9+._-]+@[a-zA-Z0-9._-]+.[a-zA-Z0-9_-]+)").Count == 1)
                {
                    _emailAddress = value;
                }
                else
                {
                    throw new Exception("Your Email Address is invalid.");
                }
            }
        }


        public string EmailMessage
        {
            get
            {
                return _emailMessage;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 1028)
                {
                    _emailMessage = value;
                }
                else
                {
                    throw new Exception("Your Email Message needs to be between 1 and 1028 characters long");
                }
            }
        }


        public string BranchCode
        {
            get
            {
                return _branchCode;
            }
            set
            {
                if (value.Length == 9 && Regex.Matches(value, "([0-9]{2}-[0-9]{3}-[0-9]{2})").Count == 1)
                {
                    _branchCode = value;
                }
                else
                {
                    throw new Exception("Your branch code is invalid, enter the numerical format e.g. 12-345-67");
                }
            }
        }


        public string IncidentCode
        {
            get
            {
                return _incidentCode;
            }
            set
            {
                if (value.Length > 0)
                {
                    _incidentCode = value;
                }
                else
                {
                    throw new Exception("Please enter an incident code.");
                }
            }
        }


    }
}