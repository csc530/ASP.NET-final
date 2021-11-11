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
		public string Description { get; set; }
		public int JobStatusId { get; set; }
		public int AccountId { get; set;}

		//parent refs
		public JobStatus JobStatus { get; set; }
		public Account Account { get; set;}
	}
}
