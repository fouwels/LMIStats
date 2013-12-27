using System;
using System.Net;
using System.Collections.Generic;
using System.Windows.Navigation;
using lmiforall_phone.templates;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using lmiforall_phone.services;

namespace lmiforall_phone
{
    public partial class MainPage : PhoneApplicationPage
    {
	    private List<JobCard.Root> _jobCards; 

        public MainPage()
        {
            InitializeComponent();
	        // Listview source = _jobCards;
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			//SOCS to display
			var socBank = new Dictionary<string, string>(); //SOC Code -> Job name
			socBank.Add("2113", "Programmer");

			var gapi = new ApiInteract();

			foreach (var soc in socBank.Keys)
			{
				var y = await gapi.GetONET(soc);
				_jobCards.Add(y);
			}
        }
    }
}