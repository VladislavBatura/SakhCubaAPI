﻿using System.ComponentModel.DataAnnotations;

namespace SakhCubaAPI.Models.DBModels
{
    public class JWT_Users
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}
