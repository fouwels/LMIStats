using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using lmiforall_phone.templates;
using Microsoft.Phone.Controls;
using lmiforall_phone.services;

namespace lmiforall_phone
{
    public partial class MainPage : PhoneApplicationPage
    {
		public ObservableCollection<JobCard.Root> JobCards { get { return _jobCards; } } 

	    private ObservableCollection<JobCard.Root> _jobCards = new ObservableCollection<JobCard.Root>(); 

        public MainPage()
        {
            InitializeComponent();
			pano.ItemsSource = JobCards;
	        //todo Listview source = _jobCards;
			//todo xaml
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
		{
			//SOCS to display
			var socBank = new Dictionary<string, string>(); //SOC Code -> Job name
			socBank.Add("2113", "Programmer");
			socBank.Add("2111", "unknown");
			socBank.Add("2112", "unknown");
			socBank.Add("2116", "unknown");
			socBank.Add("2114", "unknown");
			socBank.Add("2115", "unknown");

			var gapi = new ApiInteract();

			foreach (var soc in socBank.Keys)
			{
				var y = await gapi.GetONET(soc);
				if (y.soc != 0)
				{
				_jobCards.Add(y);	
				}
			}
		}
    }
}