using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Trio.DAL.Models.MasterModel;

namespace Trio.DAL.Models.UserModel
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } 
        [StringLength(100)]
        public string? LastName { get; set; }
        [Required]
        public int CityId { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        [StringLength(15)]
        public string? Zip { get; set; }
        public int? ProfileImage { get; set; }
        [DefaultValue(false)]
        public bool? IsActive { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        [Write(false)]
        public ICollection<ApplicationUserRole>? UserRoles { get; set; }
        [Write(false)]
        public virtual CityMaster? City { get; set; }
        [DefaultValue(false)]
        public bool IsApproved { get; set; }
        public string? GoogleId { get; set; }
        [DefaultValue(false)]
        public bool IsGoogleUser { get; set; }

    }
}
