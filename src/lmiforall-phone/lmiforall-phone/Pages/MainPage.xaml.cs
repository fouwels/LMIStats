using System.Collections.Generic;
using System.Windows.Navigation;
using lmiforall_phone.templates;
using Microsoft.Phone.Controls;
using lmiforall_phone.services;

namespace lmiforall_phone
{
    public partial class MainPage : PhoneApplicationPage
    {
	    private List<JobCard.Root> _jobCards = new List<JobCard.Root>(); 

        public MainPage()
        {
            InitializeComponent();
	        //todo Listview source = _jobCards;
			//todo xaml
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			//SOCS to display
			var socBank = new Dictionary<string, string>(); //SOC Code -> Job name
			socBank.Add("2113", "Programmer");
			socBank.Add("2114", "unknown");
			socBank.Add("2115", "unknown");
			socBank.Add("2116", "unknown");
			socBank.Add("2117", "unknown");
			socBank.Add("2118", "unknown");

			var gapi = new ApiInteract();

			foreach (var soc in socBank.Keys)
			{
				var y = await gapi.GetONET(soc);
				_jobCards.Add(y);
			}
        }
    }
}