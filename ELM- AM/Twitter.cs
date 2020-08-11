using System;
using System.Collections.Generic;
using System.Text;

namespace ELM__AM
{
    public class Twitter
    {
        public string ID { get; set; }
        public string TwitterID { get; set; }
        public string TwitterMessage { get; set; }


        public Twitter()
        {

        }

        public bool Validation()
        {
            if (TwitterID.Length > 0 && TwitterMessage.Length > 0)
            {
                return true;
            }
            return false;
        }

    }


}
