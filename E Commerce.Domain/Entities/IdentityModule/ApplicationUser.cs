using Microsoft.AspNetCore.Identity;


namespace E_Commerce.Domain.Entities.IdentityModule
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = default!;
        public Address? Address { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}
