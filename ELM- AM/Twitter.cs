using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            if (TwitterID.Length > 0 
                && TwitterMessage.Length > 0 
                && TwitterMessage.Length <= 140 
                && Regex.Matches(TwitterID, "@+[a-zA-Z0-9(_)]{3,15}").Count > 0)
            {
                return true;
            }
            return false;
        }

    }


}
