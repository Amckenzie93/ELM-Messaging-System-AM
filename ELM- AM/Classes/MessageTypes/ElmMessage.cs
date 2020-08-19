using System;

namespace ELM__AM
{

    public class ElmMessage{

        private string _header;
        private string _body;

        //Initial Message constructor - to be utilised properly in non prototype with updates to allow for injection and true modularity.
        public ElmMessage(string header, string body)
        {
            _header = header;
            _body = body;
        }

        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                if (value.Length == 10)
                {
                    _header = value;
                }
                else
                {
                    throw new Exception("Your message header is incorrect. Enter one of the fowlloing for the message type (S, E, OR T) followed by 9 numbers (example T123456789)");
                }
            }
        }

        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                if (value.Length > 0)
                {
                    _body = value;
                }
                else
                {
                    throw new Exception("Your message body needs filled in - please check your details.");
                }
            }
        }

        public string GetMessageType()
        {
            var checker = Header.Substring(0, 1);
            return checker;
        }
    }
}