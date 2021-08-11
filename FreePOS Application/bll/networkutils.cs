using FreePOS.data.dapper;
using FreePOS.data.viewmodel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Telerik.Windows.Controls;

namespace FreePOS.bll
{
    public class networkutils
    {
        //public static string apiendpointdefault = "http://localhost:8011/api/FreePOSapi";
        public static string apiendpointdefault = "http://ravicosoft.com/api/FreePOSapi";
        public static async void updatelocalsetting()
        {
            try
            {
                softwaresettingrepo ssr = new softwaresettingrepo();
                var ravicosoftuser = ssr.getbyname(commonsettingfields.ravicosoftuserid);

                var apiendpoint = apiendpointdefault;
                if (userutils.apiendpoint != null)
                {
                    apiendpoint = userutils.apiendpoint.stringvalue;
                }
                RestClient client = new RestClient(apiendpoint);
                var request = new RestRequest("updatelocalsetting");
                if (ravicosoftuser != null)
                {
                    request.AddJsonBody(new { userid = ravicosoftuser.stringvalue });
                }
                var response = await client.PostAsync<apiresponsetype>(request);
                if (response.status == "success")
                {
                    var user = Newtonsoft.Json.JsonConvert.DeserializeObject<apiresponseuserclass>(response.data);
                    userutils.updateusersetting(user);
                }
            }
            catch (Exception ex)
            {

            }
        }


        public static async void changeaccount(dynamic obj)
        {
            try
            {
                softwaresettingrepo ssr = new softwaresettingrepo();
                var ravicosoftuser = ssr.getbyname(commonsettingfields.ravicosoftuserid);
                if (ravicosoftuser == null)
                {
                    return;
                }
                var apiendpoint = apiendpointdefault;
                if (userutils.apiendpoint != null)
                {
                    apiendpoint = userutils.apiendpoint.stringvalue;
                }
                RestClient client = new RestClient(apiendpoint);
                var request = new RestRequest("changeaccount");
                obj.userid = ravicosoftuser.stringvalue;
                request.AddJsonBody(obj);
                var response = await client.PostAsync<apiresponsetype>(request);
                if (response.status == "success")
                {
                    var user = Newtonsoft.Json.JsonConvert.DeserializeObject<apiresponseuserclass>(response.data);
                    userutils.updateusersetting(user);
                    RadDesktopAlertManager manager = new RadDesktopAlertManager();
                    var alert = new RadDesktopAlert();
                    alert.Header = "Information";
                    alert.Content = "User account changed. Please restart software to apply update";
                    alert.ShowDuration = 5000;
                    System.Media.SystemSounds.Hand.Play();
                    manager.ShowAlert(alert);

                }
            }
            catch (Exception ex)
            {

            }
        }

        public static async void sendsms(string message,string[] numbers)
        {
            try
            {
                var apiendpoint = getapiendpoint();
                RestClient client = new RestClient(apiendpoint);
                var request = new RestRequest("smsfromFreePOS");
                var requestobject = new { userid = userutils.ravicosoftuserid.stringvalue,message=message,numbers= string.Join(",", numbers) };
                request.AddJsonBody(requestobject);
                otherutils.notify("Info", "Sending SMS to "+ numbers.Length + " numbers", 10000);
                var response = await client.PostAsync<apiresponsetype>(request);
            }
            catch (Exception ex)
            {

            }
        }
        public static string getapiendpoint() {
            var apiendpoint = apiendpointdefault;
            if (userutils.apiendpoint != null)
            {
                apiendpoint = userutils.apiendpoint.stringvalue;
            }
            return apiendpoint;
        }

    }
    
    
}
