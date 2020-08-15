using System;

namespace ELM__AM
{
    public class Sms
    {
        private string _id;
        private string _phoneNumber;
        private string _textmessage;

        public Sms(string id, string messageBody)
        {
            ID = id;
            var body = messageBody.Split(',');
            if (body.Length == 2)
            {
                PhoneNumber = body[1];
                Textmessage = body[0];
            }
            else
            {
                throw new Exception("Please fully enter all body details");
            }
        }

        public Sms(string id, string number, string message)
        {
            ID = id;
            PhoneNumber = number;
            Textmessage = message;
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
