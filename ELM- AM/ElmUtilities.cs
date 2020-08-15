using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ELM__AM
{
    class ElmUtilities
    {

        public static string GetHashTags(string val, DataCollection data)
        {

            string regex = @"(#+[a-zA-Z0-9(_)]{1,})";
            MatchCollection matched = Regex.Matches(val, regex);
            foreach (var item in matched)
            {
                data.twitterTrending.Add(item.ToString());
            }

            return val;
        }


        public static bool IsNumber(string number)
        {
            foreach (char val in number.Replace(" ", ""))
            {
                if (val < '0' || val > '9')
                    return false;
            }
            return true;
        }


        public static bool IsUniqueId(string id, DataCollection data)
        {
            if (id.Length != 10)
            {
                return false;
            }
            else{
                var idNumbers = id.Substring(1, 9);
                if (ElmUtilities.IsNumber(idNumbers))
                {
                    foreach (var item in data.smsUniqueID)
                    {
                        if (item == id)
                        {
                            return false;
                        }
                    }

                    foreach (var item in data.emailUniqueID)
                    {
                        if (item == id)
                        {
                            return false;
                        }
                    }

                    foreach (var item in data.twitterUniqueID)
                    {
                        if (item == id)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string LinkCheck(string val, DataCollection data)
        {
            string regex = @"((http|www|https|ftp):\/\/)?[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?";
            MatchCollection replaced = Regex.Matches(val, regex);
            foreach (var item in replaced)
            {
                data.quarantinedList.Add(item.ToString());
                val = Regex.Replace(val, regex, "<URL Quarantined>");
            }
            return val;
        }


        //method to write JSON to file
        public static void exportJSON(DataCollection data)
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DateTime.Today.ToString("yyy-MM-dd") + " - ELM JSON EXPORT" + ".json");
            using (StreamWriter file = File.CreateText(path))
            {
                try
                {
                    using (JsonTextWriter jw = new JsonTextWriter(file))
                    {
                        jw.WriteStartObject();
                        jw.WritePropertyName("All SMS Messages");
                        jw.WriteStartArray();
                        foreach (var item in data.smsMessages)
                        {
                            string json = JsonConvert.SerializeObject(item);
                            jw.WriteValue(json + ",");
                        }
                        jw.WriteEndArray();
                        jw.WritePropertyName("All Twitter Messages");
                        jw.WriteStartArray();
                        foreach (var item in data.twitterMessages)
                        {
                            string json = JsonConvert.SerializeObject(item); ;
                            jw.WriteValue(json + ",");
                        }
                        jw.WriteEndArray();
                        jw.WritePropertyName("All Email Messages");
                        jw.WriteStartArray();
                        foreach (var item in data.emailMessages)
                        {
                            string json = JsonConvert.SerializeObject(item); ;
                            jw.WriteValue(json + ",");
                        }
                        jw.WriteEndArray();
                        jw.WritePropertyName("All Quarantined Links");
                        jw.WriteStartArray();
                        foreach (var item in data.quarantinedList)
                        {
                            string json = JsonConvert.SerializeObject(item); ;
                            jw.WriteValue(json + ",");
                        }
                        jw.WriteEndArray();
                        jw.WriteEndObject();
                    }
                    MessageBox.Show("Your JSON file has been exported to your Desktop.", "Json Export Successful");
                }
                catch
                {
                    MessageBox.Show("The export has failed, please check your data or contact the system administrator.", "Json Export Failed");
                }
            }
        }


        //generate unique id - advance functionality improvement for other form fields.
        public static string GenUniqueId(string type, DataCollection data)
        {
            var number = 1;
            var newUnique = type + String.Format("{0:D9}", number);
            if (type == "S")
            {
                while (data.smsUniqueID.Contains(newUnique))
                {
                    newUnique = type + String.Format("{0:D9}", number++);
                }
                data.smsUniqueID.Add(newUnique);
            }
            else if (type == "T")
            {
                while (data.twitterUniqueID.Contains(newUnique))
                {
                    newUnique = type + String.Format("{0:D9}", number++);
                }
                data.twitterUniqueID.Add(newUnique);
            }
            else
            {
                while (data.emailUniqueID.Contains(newUnique))
                {
                    newUnique = type + String.Format("{0:D9}", number++);
                }
                data.emailUniqueID.Add(newUnique);
            }
            return newUnique;
        }

    }
}
