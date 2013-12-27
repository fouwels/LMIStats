using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
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
	public class ApiInteract
	{
		public async Task<List<JobCard.Root>> GetData()
		{
			var request = (HttpWebRequest)WebRequest.Create("http://api.lmiforall.org.uk/api/onet/levels/2113");
			var response = await request.GetResponseAsync();

			string responsePage;

			using (var stream = response.GetResponseStream())
			{
				using (var reader = new StreamReader(stream))
				{
					responsePage = reader.ReadToEnd();
				}
			}

			if (response.StatusCode == HttpStatusCode.Accepted)
			{
				return JsonConvert.DeserializeObject<List<JobCard.Root>>(responsePage);
			}
			else
			{
				return new List<JobCard.Root>();
			}
		}
	}
}
