using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	public class JobPost
	{
		public int JobPostId { get; set; }

		[Required, Display(Name = "Job")]
		public string JobName { get; set; }
		public int JobStatusId { get; set; }
		public int PostedById { get; set;}
		//child reference

		////parent refs
		//public Account PostedBy { get; set;}
		[Display(Name = "Status")]
		public JobStatus JobStatus { get; set; }
		public Account PostedBy { get; set;}
	}
}
