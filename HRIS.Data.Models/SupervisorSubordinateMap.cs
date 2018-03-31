using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class SupervisorSubordinateMap
    {
        public int Id { get; set; }

        public int SupervisorId { get;set; }


        public int SubordinateId { get; set; }
    }
}
