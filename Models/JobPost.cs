using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	public class JobPost
	{
		[Required]
		public string JobName { get; set; }
		[Display(Name = "Job ID")]
		public int JobPostID { get; set; }		
		public JobStatus JobStatus { get; set; }
		[Required, Display(Name ="Posted by: ")]
		public Account PostedBy { get; set; }
		public Account FufilledBy { get; set; }
		public string Description { get; set; }
		[Required]
		public bool Fulfilled { get; set; }
	}
}
