using System;

namespace ELM__AM
{
    public class Sms
    {
        private string _id;
        private string _phoneNumber;
        private string _textmessage;

        //Manual SMS input contructor
        public Sms(string id, string messageBody, DataCollection data)
        {
            ID = id;
            var body = messageBody.Split(',');
            if (body.Length == 2)
            {
                PhoneNumber = body[1];
                Textmessage = ElmUtilities.WordAbreviations(body[0]);
            }
            else
            {
                throw new Exception("Please fully enter all body details");
            }
        }

        //Import SMS input contructor
        public Sms(string id, string number, string message, DataCollection data)
        {
            ID = id;
            PhoneNumber = number;
            Textmessage = ElmUtilities.WordAbreviations(message);
        }


        //Below are all my Getter and Setters with built in validation and error handling.
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

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value.Length >= 7 && value.Length <= 15 && ElmUtilities.IsNumber(value))
                {
                    _phoneNumber = value;
                }
                else
                {
                    throw new Exception("The SMS phone number must be between 7 and 15 characters long and consist of only numbers");
                }
            }
        }

        public string Textmessage
        {
            get
            {
                return _textmessage;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 140)
                {
                    _textmessage = value;
                }
                else
                {
                    throw new Exception("The SMS message entered must be between 0 and 140 characters.");
                }
            }
        }


    }
}
