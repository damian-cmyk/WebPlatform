namespace studentap.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Utilizatorul care a lăsat feedback
        public int Rating { get; set; } // Rating-ul 1-5

        public User User { get; set; } // Relație cu utilizatorul
    }
}
