using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using studentap.Models;


namespace studentap.Data
{
    public class DatabaseContext
    {
        private readonly SQLiteAsyncConnection _database;

        // Constructor: inițializează baza de date
        public DatabaseContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            // Crearea tabelelor (se execută o singură dată)
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Appointment>().Wait();
        }

        // CRUD pentru User
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserAsync(string username, string password)
        {
            return _database.Table<User>()
                           .FirstOrDefaultAsync(u => u.Name == username && u.Password == password);
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<int> SaveAppointmentAsync(Appointment appointment)
        {
            if (appointment.Id != 0)
            {
                return _database.UpdateAsync(appointment);
            }
            else
            {
                return _database.InsertAsync(appointment);
            }
        }


        public Task<int> DeleteAppointmentAsync(Appointment appointment)
        {
            return _database.DeleteAsync(appointment);
        }

        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            var appointments = await _database.Table<Appointment>().ToListAsync();

            foreach (var appointment in appointments)
            {
                var student = await _database.Table<User>().FirstOrDefaultAsync(u => u.Id == appointment.StudentId);
                var client = await _database.Table<User>().FirstOrDefaultAsync(u => u.Id == appointment.ClientId);

                appointment.StudentName = student?.Name ?? "Unknown";
                appointment.ClientName = client?.Name ?? "Unknown";
            }

            return appointments;
        }

        public Task<int> SaveFeedbackAsync(Feedback feedback)
        {
            return _database.InsertAsync(feedback);
        }


    }
}
