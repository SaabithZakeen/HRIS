using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
	public class Designations
	{
		public int Id { get; set; }

		public string Designation { get; set; }

		public bool Status { get; set; }

        public string DesignationName { get; set; }
    }
}
