﻿using System.ComponentModel.DataAnnotations;

namespace MedicalTools.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string cardNo { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
