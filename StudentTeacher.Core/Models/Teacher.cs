using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTeacher.Core.Models
{
    public class Teacher
    {

        [Column("TeacherId")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Teacher's name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        public string? Subject { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
