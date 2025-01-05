using Microsoft.AspNetCore.Identity;

namespace TestingPatient.Models
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }
    }
}
