namespace studentap
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnAddAppointmentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAppointmentPage());
        }

        private async void OnViewAppointmentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppointmentsPage());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Resetează utilizatorul logat
            App.LoggedInUser = null;

            // Setează pagina de login ca `MainPage`
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private async void OnLeaveFeedbackClicked(object sender, EventArgs e)
        {

            // Navighează la pagina AddFeedbackPage
            await Navigation.PushAsync(new AddFeedbackPage());
        }



    }

}
