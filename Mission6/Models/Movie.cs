using System.ComponentModel.DataAnnotations;

// Model = Class

namespace Mission6.Models
{
    public class Movie // Becomes a Table
    {
        public int MovieId { get; set; } // Allows all info to have a getter and a setter

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Year { get; set; } = string.Empty; // Stored as string to make ranges easy

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string Rating { get; set; } = string.Empty;

        public bool Edited { get; set; } // True False

        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
        
    }
}