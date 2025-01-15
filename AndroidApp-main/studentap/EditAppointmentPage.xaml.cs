using studentap.Models;

namespace studentap
{
    public partial class EditAppointmentPage : ContentPage
    {
        private Appointment _appointment;

        public EditAppointmentPage(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;

            // Prepopulează câmpurile cu datele existente
            StudentIdEntry.Text = _appointment.StudentId.ToString();
            ClientIdEntry.Text = _appointment.ClientId.ToString();
            DatePicker.Date = _appointment.Date;
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            _appointment.StudentId = int.Parse(StudentIdEntry.Text);
            _appointment.ClientId = int.Parse(ClientIdEntry.Text);
            _appointment.Date = DatePicker.Date;

            await App.Database.SaveAppointmentAsync(_appointment);
            await DisplayAlert("Success", "Appointment updated!", "OK");

            await Navigation.PopAsync();
        }
    }
}
