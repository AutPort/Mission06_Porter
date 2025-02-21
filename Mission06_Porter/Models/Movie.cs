using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Porter.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be 1888 or later.")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public bool Edited { get; set; } // boolean for yes/no (true/false or 1/0)

        public string? LentTo { get; set; } // optional

        [Required]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25, ErrorMessage = "Maximum length is 25 characters.")] // limit notes to 25 characters
        public string? Notes { get; set; }  // optional
    }
}
