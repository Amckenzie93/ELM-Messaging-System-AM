using System;
using System.Collections.Generic;
using System.Text;

namespace ELM__AM{

    public class ElmMessage{

        public string Header { get; set; }
        public string Body { get; set; }

        public ElmMessage(string header, string body)
        {
            Header = header;
            Body = body;

            
        }

        public string GetMessageType()
        {
            var checker = Header.Substring(0,1);
            return checker;
        }


    }

   
}