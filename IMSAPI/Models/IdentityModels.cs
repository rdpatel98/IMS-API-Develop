using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IMSAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public Worker Worker { get; set; }
        public int? WorkerId { get; set; }
        //public Organization Organization { get; set; }
        //public int? OrganizationId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class AppUserLogin : IdentityUserLogin<int>
    {
        //public Organization Organization { get; set; }
        //public int? OrganizationId { get; set; }
    }

    public class AppUserRole : IdentityUserRole<int> { }

    public class AppUserClaim : IdentityUserClaim<int> { }

    public class AppRole : IdentityRole<int, AppUserRole>
    {
        public Organization Organization { get; set; }
        public int? OrganizationId { get; set; }
    }
}