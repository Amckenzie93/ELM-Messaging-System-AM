using System.Collections.Generic;

namespace ELM__AM
{
    public class DataCollection
    {
        //all my database layer collections, split into each type for performance to allow better scailing and optimisation.
        public List<Sms> smsMessages = new List<Sms>();
        public List<Email> emailMessages = new List<Email>();
        public List<Email> SIRemailMessages = new List<Email>();
        public List<Twitter> twitterMessages = new List<Twitter>();

        public HashSet<string> smsUniqueID = new HashSet<string>();
        public HashSet<string> twitterUniqueID = new HashSet<string>();
        public HashSet<string> emailUniqueID = new HashSet<string>();

        public List<string> twitterHandleUse = new List<string>();
        public List<string> twitterTrending = new List<string>();

        public List<string> quarantinedList = new List<string>();

        //error log for imported messages which failed validation.
        public List<string> importErrors = new List<string>();


        private static DataCollection _instance;

        protected DataCollection()
        {

        }

        // Method called whenever the data object is requested, if an instance exists only ever return that one instance - Singleton pattern
        public static DataCollection Instance()
        {
            if (_instance == null)
            {
                _instance = new DataCollection();
            }

            return _instance;
        }
    }
}

