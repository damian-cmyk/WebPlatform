using studentap.Models;

namespace studentap
{
    public partial class AddFeedbackPage : ContentPage
    {
        public AddFeedbackPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitFeedbackClicked(object sender, EventArgs e)
        {
            // Validare câmpuri
            if (string.IsNullOrWhiteSpace(RatingEntry.Text))
            {
                await DisplayAlert("Error", "Please enter a rating.", "OK");
                return;
            }

            if (!int.TryParse(RatingEntry.Text, out int rating) || rating < 1 || rating > 5)
            {
                await DisplayAlert("Error", "Rating must be a number between 1 and 5.", "OK");
                return;
            }

            // Preluăm UserId din utilizatorul logat
            int userId = App.LoggedInUser?.Id ?? 0;
            if (userId == 0)
            {
                await DisplayAlert("Error", "Could not determine the logged-in user.", "OK");
                return;
            }

            // Creăm feedback-ul
            var feedback = new Feedback
            {
                UserId = userId,
                Rating = rating,// Poți adăuga review-ul dacă dorești ulterior
            };

            // Salvăm feedback-ul în baza de date
            await App.Database.SaveFeedbackAsync(feedback);

            // Confirmare și navigare înapoi
            await DisplayAlert("Success", "Feedback saved!", "OK");
            await Navigation.PopAsync();
        }
    }
}
