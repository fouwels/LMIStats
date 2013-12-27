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
using lmiforall_phone.templates;
using Newtonsoft.Json;

namespace lmiforall_phone.services
{
    public class MyJsonThing
    {
        private string x;

        public JobCard DoStuff()
        {
            var request = (HttpWebRequest)HttpWebRequest.Create("http://api.lmiforall.org.uk/api/onet/levels/2113");
            var x = request.BeginGetResponse(GetCallback, request);

            JsonConvert.DeserializeObject<JobCard<JobCard.RootObject>>(x);

            return new JobCard();

        }

        private void GetCallback(IAsyncResult result)
        {
            var request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                WebResponse response = request.EndGetResponse(result);
                x = response.GetResponseStream().ToString();
            }
        }
    }
}
