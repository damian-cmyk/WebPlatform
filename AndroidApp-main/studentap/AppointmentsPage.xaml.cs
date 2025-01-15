using studentap.Models;

namespace studentap
{
    public partial class AppointmentsPage : ContentPage
    {
        public List<Appointment> Appointments { get; set; }

        public AppointmentsPage()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private async void LoadAppointments()
        {
            Appointments = await App.Database.GetAppointmentsAsync();
            BindingContext = this;
        }
    }
}
