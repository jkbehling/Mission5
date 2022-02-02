using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string Lent { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
