using Microsoft.AspNetCore.Identity;

namespace FAQs.Data.Entities;

public class ApiUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}