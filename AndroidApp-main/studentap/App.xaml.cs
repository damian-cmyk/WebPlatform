using System.IO;
using studentap.Data;
using studentap.Models;

namespace studentap
{
    public partial class App : Application
    {
        public static DatabaseContext Database { get; private set; }
        public static User LoggedInUser { get; set; }

        public App()
        {
            InitializeComponent();
            SeedDatabaseAsync();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "studentappointments.db");
            Database = new DatabaseContext(dbPath);

            MainPage = new NavigationPage(new LoginPage());
        }

        private async Task SeedDatabaseAsync()
        {
            var user = await Database.GetUserAsync("admin", "admin");
            if (user == null)
            {
                await Database.SaveUserAsync(new Models.User
                {
                    Name = "admin",
                    Password = "admin",
                    Role = "Admin"
                });
            }
        }
    }
}
