using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	public class Account
	{
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }
		public int AccountID { get; set; }
	}
}