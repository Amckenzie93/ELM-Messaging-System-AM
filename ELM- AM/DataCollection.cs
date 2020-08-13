using System.Collections.Generic;

namespace ELM__AM
{
    public class DataCollection
    {
        public List<Sms> smsMessages = new List<Sms>();
        public List<Email> emailMessages = new List<Email>();
        public List<Twitter> twitterMessages = new List<Twitter>();

        public HashSet<string> smsUniqueID = new HashSet<string>();
        public HashSet<string> twitterUniqueID = new HashSet<string>();
        public HashSet<string> emailUniqueID = new HashSet<string>();

        public List<string> twitterHandleUse = new List<string>();
        public List<string> twitterTrending = new List<string>();
        
        public List<string> quarantinedList = new List<string>();

        public DataCollection()
        {

        }

    }


}
