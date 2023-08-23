using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trio.DAL.Models.MasterModel
{
    public class CityMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        [Write(false)]
        public StateMaster State { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }

    }
}
