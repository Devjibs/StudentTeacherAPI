using Microsoft.AspNetCore.Identity;

namespace StudentTeacher.Core.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
