using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using lmiforall.phone_services;

namespace lmiforall_phone.Pages
{
    public partial class LandinPage : PhoneApplicationPage
    {
        public LandinPage()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_OnClick(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Here is some non existant help content - sorry. the quick brown fox jumoed voer the lazy dog, the quick brown fox jumped voer the lazy dog",
                "Help!", MessageBoxButton.OK);
        }

        private void UserGo_OnClick(object sender, RoutedEventArgs e)
        {
            SpinningAnimation.Begin();
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
        }
    }
}