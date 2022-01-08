using System.ComponentModel.DataAnnotations;

namespace StudentTeacher.Core.Dtos;

public class TeacherDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Subject { get; set; }
}

public class TeacherCreationDto : TeacherAddAndUpdateDto
{
}

public class TeacherUpdateDto : TeacherAddAndUpdateDto
{
}


public abstract class TeacherAddAndUpdateDto
{
    [Required(ErrorMessage = "Teacher name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; set; }


    [Required(ErrorMessage = "Subject is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum length for Country is 20 characters.")]
    public string? Subject { get; set; }

    public IEnumerable<StudentCreationDto>? Students { get; set; }
}
