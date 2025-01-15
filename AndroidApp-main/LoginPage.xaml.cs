using studentap.Models;

namespace studentap
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }


        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            var user = await App.Database.GetUserAsync(username, password);

            if (user == null)
            {
                ErrorLabel.Text = "Invalid username or password.";
                ErrorLabel.IsVisible = true;
                return;
            }

            // Setează utilizatorul logat
            App.LoggedInUser = user;

            // Setează `MainPage` la `AppointmentsPage`
            App.Current.MainPage = new NavigationPage(new MainPage());
        }



    }
}
