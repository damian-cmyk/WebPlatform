using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace studentap.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int StudentId { get; set; } // Legat de User (Student)
        public int ClientId { get; set; } // Legat de User (Client)

        public DateTime Date { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } // Ex: "Pending", "Confirmed"

        [NotMapped]
        public string StudentName { get; set; } = string.Empty;

        [NotMapped]
        public string ClientName { get; set; } = string.Empty;
    }
}
