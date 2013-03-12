using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using lmiforall.phone_services;
using lmiforall.phone_templates;

namespace lmiforall_phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public int RandomNumber()
        {
            var random = new Random();
            return random.Next(0, 100);
        }

        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            var x = new MyJsonThing();
            x.DoStuff();

        }
    }
}