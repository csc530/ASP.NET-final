using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	public class JobPost
	{
		[Required, Display(Name = "Job")]
		public string JobName { get; set; }
		[Display(Name = "Job ID")]
		public int JobPostID { get; set; }
		[Required, Display(Name = "Posted by")]
		public Account PostedBy { get; set; }
		//why I need the Account ID and only one class variable of type Account IDK
		public int AccountId { get; set; }
		public string PostedByID { get; set; }
		public string FufilledByID { get; set; }


		[Required]
		public string Description { get; set; }
		[Required]
		public bool Fulfilled { get; set; }
		
		[Display(Name ="Staus")]
		public JobStatus JobStatus { get; set; }

		//refs
		
	}
}
