using System.ComponentModel.DataAnnotations;

namespace Mission06_Porter.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; } // optional - boolean for yes/no (true/false)

        public string? LentTo { get; set; } // optional

        [MaxLength(25, ErrorMessage = "Maximum length is 25 characters.")] // limit notes to 25 characters
        public string? Notes { get; set; }  // optional
    }
}
