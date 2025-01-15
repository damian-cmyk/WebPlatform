﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace studentap.Models // Înlocuiește cu namespace-ul proiectului tău
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Role { get; set; } // Ex: "Student" sau "Client"

        [MaxLength(100)]
        public string Password { get; set; }
    }
}

