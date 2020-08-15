using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ELM__AM
{
    public class Twitter
    {
        private string _id;
        private string _twitterID;
        private string _twitterMessage;


        public Twitter(string id, string messageBody, DataCollection data)
        {
            ID = id;

            var body = messageBody.Split(',');
            if (body.Length == 2)
            {
                TwitterID = body[0];
                TwitterMessage = GetHashTags(ElmUtilities.WordAbreviations(body[1]), data);
            }
            else
            {
                throw new Exception("Please fully enter all body details");
            }
        }


        public Twitter(string id, string twitterID, string messageBody, DataCollection data)
        {
            ID = id;
            TwitterID = twitterID;
            TwitterMessage = GetHashTags(ElmUtilities.WordAbreviations(messageBody), data);
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


        public string TwitterID
        {
            get
            {
                return _twitterID;
            }
            set
            {
                if (value.Length > 0 && Regex.Matches(value, "@+[a-zA-Z0-9(_)]{3,15}").Count > 0)
                {
                    _twitterID = value;
                }
                else
                {
                    throw new Exception("Please check your Twitter sender ID, must include an '@' symbol, and be between 3 and 15 characters long.");
                }
            }
        }

        public string TwitterMessage
        {
            get
            {
                return _twitterMessage;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 140)
                {
                    _twitterMessage = value;
                }
                else
                {
                    throw new Exception("Please check your Twitter message - should be between 1 and 140 characters long.");
                }
            }
        }

        public string GetHashTags(string val, DataCollection data)
        {
            string regex = @"(#+[a-zA-Z0-9(_)]{1,})";
            MatchCollection matched = Regex.Matches(val, regex);
            foreach (var item in matched)
            {
                data.twitterTrending.Add(item.ToString());
            }

            return val;
        }

    }


}
