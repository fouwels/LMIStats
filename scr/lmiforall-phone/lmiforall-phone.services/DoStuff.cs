using System;
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
    public class ApiThing
    {
        string _results;
        public string DoStuff()
        {
            System.Uri targetUri = new System.Uri("http://api.lmiforall.org.uk/api/onet/importance/2113");

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUri);
            request.BeginGetResponse(new AsyncCallback(ReadWebRequestCallback), request);

            var x = JsonConvert.DeserializeObject<JobCard>(_results);

            return "AAAA";
        }
        private void ReadWebRequestCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.EndGetResponse(callbackResult);

            using (StreamReader httpwebStreamReader = new StreamReader(myResponse.GetResponseStream()))
            {
                 _results = httpwebStreamReader.ReadToEnd();
            }
            myResponse.Close();
        }

    }
}
