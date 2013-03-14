using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using lmiforall.phone_templates;

namespace lmiforall.phone_services
{
    public class MyJsonThing
    {
        private string x;

        public JobCard DoStuff()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://api.lmiforall.org.uk/api/onet/levels/2113");
            request.BeginGetResponse(GetCallback, request);


            //List<string> x;
            //JsonConvert.DeserializeObject<JobCard<JobCard.RootObject>>();

            return new JobCard();

        }

        private void GetCallback(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                WebResponse response = request.EndGetResponse(result);
                x = response.GetResponseStream().ToString();
            }
        }
    }
}
