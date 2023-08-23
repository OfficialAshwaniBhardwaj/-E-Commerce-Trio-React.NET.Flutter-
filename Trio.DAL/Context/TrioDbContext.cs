using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trio.DAL.Models.MasterModel;
using Trio.DAL.Models.UserModel;

namespace Trio.DAL.Context
{
    public class TrioDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
                                                         ApplicationUserRole, IdentityUserLogin<string>,
                                                        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters { get; set; }
        public DbSet<CountryMaster> CountryMasters { get; set; }
    }
}
