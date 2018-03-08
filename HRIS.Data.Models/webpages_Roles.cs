using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class webpages_Roles
    {
        [Key]
        public virtual int RoleId { get; set; }

        public virtual string RoleName { get; set; }
    }
}
