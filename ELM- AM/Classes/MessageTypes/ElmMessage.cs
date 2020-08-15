using System;

namespace ELM__AM
{

    public class ElmMessage{

        private string _header { get; set; }
        public string Body { get; set; }

        public ElmMessage(string header, string body)
        {
            _header = header;
            Body = body;
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
                    throw new Exception("Message header ID is incorrect.");
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