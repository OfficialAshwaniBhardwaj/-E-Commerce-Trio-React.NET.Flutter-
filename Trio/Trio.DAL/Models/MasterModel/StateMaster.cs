using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trio.DAL.Models.MasterModel
{
    public class StateMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        [Write(false)]
        public CountryMaster Country { get; set; }
        [Write(false)]
        public ICollection<CityMaster> Cities { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

    }
}
