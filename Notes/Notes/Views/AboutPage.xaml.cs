using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.zeon.ua/?lang=en");
        }
        async void OnButtonClicked2(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://support.zeon.ua/");


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        async void CallButton2(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            if (!string.IsNullOrEmpty("+380442064363"))
            {
                await Call("+380442064363");
            }


        }

        async void CallButton(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            if (!string.IsNullOrEmpty(txtNum.Text))
            {
                await Call(txtNum.Text);
            }


        }

        public System.Windows.Input.ICommand TapCommand2 => new Command<string>(async (namber) =>
        {
             PhoneDialer.Open(namber);
        });


        public System.Windows.Input.ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public async Task Call(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (FeatureNotSupportedException ex)
            {
                txtNum.Text = "Phone Dialer is not supported on this device.";
            }
            catch (Exception ex)
            {
                // Other error has occurred.  
            }


        }
    }
}