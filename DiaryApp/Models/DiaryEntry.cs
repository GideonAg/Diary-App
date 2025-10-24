using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a title")]
        //[StringLength(maximumLength:100, MinimumLength =3, ErrorMessage ="Title should be between 3 to 100 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage ="Please enter the content")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please select a date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
 }
