using FreePOS.data.dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace FreePOS.bll
{
    class otherutils
    {
        static RadDesktopAlertManager manager = new RadDesktopAlertManager();
        
        public static void notify(string title,string text, int timems)
        {
            var alert = new RadDesktopAlert();
            alert.Header = title;
            alert.Content = text;
            alert.ShowDuration = timems;
            System.Media.SystemSounds.Hand.Play();
            manager.ShowAlert(alert);
        }

        public static bool checkmessagevalidation(string message, string[] numbers) 
        {
            if (message == "")
            {
                otherutils.notify("Info", "Type message", 10000);
                return false;
            }
            if (numbers.Length == 0)
            {
                otherutils.notify("Info", "No valid numbers selected", 10000);
                return false;
            }
            var smsplan = userutils.ravicosoftsmsplan;
            if (smsplan == null || smsplan.stringvalue == "none" || smsplan.stringvalue == "" || smsplan.stringvalue == "undefined")
            {
                otherutils.notify("Info", "Please update your message plan to send sms", 10000);
                return false;
            }
            return true;
        }

        public static string[] parsenumbersfromdynamiclist(dynamic obj) 
        {
            var numbers = new List<string>();
            if (obj is string)
            {
                var parsednumber = parsenumberforsms(obj);
                if (parsednumber != "")
                {
                    numbers.Add(parsednumber);
                }
            }
            else if (obj is string[])
            {
                for (int i = 0; i < obj.length; i++)
                {
                    var parsednumber = parsenumberforsms(obj[i]);
                    if (parsednumber != "")
                    {
                        numbers.Add(parsednumber);
                    }

                }
            }
            else if (obj is List<string>)
            {
                for (int i = 0; i < obj.Count(); i++)
                {
                    var parsednumber = parsenumberforsms(obj[i]);
                    if (parsednumber != "")
                    {
                        numbers.Add(parsednumber);
                    }

                }
            }
            else if (obj is data.dapper.user) 
            {
                var parsednumber = parsenumberfromuserobject(obj);
                if (parsednumber != "")
                {
                    numbers.Add(parsednumber);
                }
            }
            else
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    var ob = obj[i];
                    var parsednumber = parsenumberfromuserobject(ob);
                    if (parsednumber != "")
                    {
                        numbers.Add(parsednumber);
                    }
                }
                
            }
            return numbers.ToArray();
        }

        public static string[] parsenumbersfromcommaorspaceseperatedstring(string commaorspaceseperatednumbers)
        {

            var numbers = new List<string>();
            string[] obj = commaorspaceseperatednumbers.Split(new[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < obj.Length; i++)
            {
                var parsednumber = parsenumberforsms(obj[i]);
                if (parsednumber != "")
                {
                    numbers.Add(parsednumber);
                }

            }
            return numbers.ToArray();
        }
        public static string parsenumberfromuserobject(data.dapper.user user)
        {
            string res = "";
            var phone1exists = true;
            var phone2exists = true;
            if (user.phone == null || user.phone == "") 
            {
                phone1exists = false;
            }
            if (user.phone2 == null || user.phone2 == "")
            {
                phone2exists = false;
            }

            if (!phone1exists && !phone2exists)
            {
                return res;
            }
            else 
            {
                var parsednumber = "";
                if (phone1exists)
                {
                    parsednumber = parsenumberforsms(user.phone);
                }
                if (parsednumber=="") 
                {
                    if (phone2exists) 
                    {
                        parsednumber = parsenumberforsms(user.phone2);
                    }
                }
                if (parsednumber!="") 
                {
                    res = parsednumber;
                }
                return res;
            }
        }
        public static string parsenumberforsms(string num)
        {
            var parsednumber = "";
            parsednumber = parsenumber(num);
            if (parsednumber != "")
            {
                parsednumber += "+92" + parsednumber;
            }
            return parsednumber;
        }
        public static string parsenumber(string num)
        {
            num = Regex.Replace(num, @"[^\d]", "");
            try {
                if (num.Substring(0, 4) == "0092")
                {
                    num = num.Substring(4, num.Length - 4);
                }
            }
            catch (Exception ex)
            {
                
            }
            

            try
            {
                if (num.Substring(0, 3) == "092")
                {
                    num = num.Substring(3, num.Length - 3);
                }
            }
            catch (Exception ex)
            {

            }
            

            try
            {
                if (num.Substring(0, 2) == "92")
                {
                    num = num.Substring(2, num.Length - 2);
                }
            }
            catch (Exception ex)
            {

            }
            

            try
            {
                if (num.Substring(0, 1) == "0")
                {
                    num = num.Substring(1, num.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }

            if (num.Length == 10)
            {
                return num;
            }
            else
            {
                return "";
            }
        }
    }
}
