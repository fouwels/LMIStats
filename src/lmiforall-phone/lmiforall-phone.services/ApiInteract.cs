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
		public async Task<JobCard.Root> GetONET(string level)
		{
			var request = (HttpWebRequest)WebRequest.Create("http://api.lmiforall.org.uk/api/v1/onet/levels/" + level);

			var response = await request.GetResponseAsync();

			string responsePage;

			using (var stream = response.GetResponseStream())
			{
				using (var reader = new StreamReader(stream))
				{
					responsePage = reader.ReadToEnd();
				}
			}

			if (response.StatusCode == HttpStatusCode.OK)
			{
				try
				{
					var x = JsonConvert.DeserializeObject<JobCard.Root>(responsePage);
					foreach (var skill in x.skills)
					{
						skill.score = skill.score*100; //better numbers
					}
					return x;
				}
				catch (Exception ex)
				{
					throw;
				}
				
			}
			else
			{
				return new JobCard.Root();
			}
		}
	}
}
