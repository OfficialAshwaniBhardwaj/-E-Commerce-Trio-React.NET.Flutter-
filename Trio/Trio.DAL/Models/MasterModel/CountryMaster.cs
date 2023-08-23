using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trio.DAL.Models.UserModel;

namespace Trio.DAL.Models.MasterModel
{
    public class CountryMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [Write(false)]
        public ICollection<StateMaster> States { get; set; }
        [Write(false)]
        public ICollection<ApplicationUser> Users { get; set; }

    }
}
