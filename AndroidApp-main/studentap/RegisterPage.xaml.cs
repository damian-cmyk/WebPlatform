using studentap.Models;

namespace studentap
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ErrorLabel.Text = "Please fill in all fields.";
                ErrorLabel.IsVisible = true;
                return;
            }

            if (password != confirmPassword)
            {
                ErrorLabel.Text = "Passwords do not match.";
                ErrorLabel.IsVisible = true;
                return;
            }

            // Verific? dac? utilizatorul exist? deja
            var existingUser = await App.Database.GetUserAsync(username, password);
            if (existingUser != null)
            {
                ErrorLabel.Text = "Username already exists.";
                ErrorLabel.IsVisible = true;
                return;
            }

            // Creeaz? utilizatorul
            await App.Database.SaveUserAsync(new User
            {
                Name = username,
                Password = password,
                Role = "User" // Implicit, to?i utilizatorii vor avea rolul "User"
            });

            await DisplayAlert("Success", "Account created successfully!", "OK");
            await Navigation.PopAsync(); // Revino la pagina anterioar? (LoginPage)
        }
    }
}
