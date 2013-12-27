using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

            // Set the data context of the listbox control to the sample data
	        // Listview source = _jobCards;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

	        var gapi = new ApiInteract();
	        _jobCards = gapi.GetData().Result;

        }
    }
}