using studentap.Models;

namespace studentap
{
    public partial class AddAppointmentPage : ContentPage
    {
        public AddAppointmentPage()
        {
            InitializeComponent();
        }

        private async void OnSaveAppointmentClicked(object sender, EventArgs e)
        {
            // Validare câmpuri
            if (string.IsNullOrWhiteSpace(ClientIdEntry.Text) ||
                string.IsNullOrWhiteSpace(StatusEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            if (!int.TryParse(ClientIdEntry.Text, out int clientId))
            {
                await DisplayAlert("Error", "Client ID must be a valid number.", "OK");
                return;
            }

            // Prelu?m StudentId din utilizatorul logat
            int studentId = App.LoggedInUser?.Id ?? 0;
            if (studentId == 0)
            {
                await DisplayAlert("Error", "Could not determine the logged-in user.", "OK");
                return;
            }

            // Cre?m o nou? programare
            var appointment = new Appointment
            {
                StudentId = studentId,
                ClientId = clientId,
                Date = DatePicker.Date,
                Status = StatusEntry.Text
            };

            // Salv?m programarea în baza de date
            await App.Database.SaveAppointmentAsync(appointment);

            // Confirmare ?i navigare înapoi
            await DisplayAlert("Success", "Appointment saved!", "OK");
            await Navigation.PopAsync();
        }
    }
}
