using Microsoft.AspNetCore.Identity;

namespace Resturent.Models
{ // ApplicationUser class extends IdentityUser, which contains all default user-related properties 
    // such as Id, UserName, Email, PasswordHash, etc.
    // By inheriting from IdentityUser, we can add custom properties specific to our application.
    public class ApplicationUser : IdentityUser
    {
        // Navigation property: represents the one-to-many relationship between ApplicationUser and Order.
        // A single user can have multiple orders.
        // The '?' means it can be null (no orders yet)..
        //ICollection<Order> is used to represent a modifiable, trackable collection of related entities — ideal for one-to-many relationships in EF Core.
        public ICollection<Order>? Orders { get; set; }
    }
}
