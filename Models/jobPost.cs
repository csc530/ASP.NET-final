using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		[Display(Name ="Status")]
		public int JobStatusId { get; set; }
		[Required(ErrorMessage ="Create an Account to be selected in professionals tab",AllowEmptyStrings =false), Display(Name = "Posted by")]
		public int AccountId { get; set; }
		[Display(Name ="Accepted by")]
		public int? AcceptedById { get; set; }

		//parent refs
		public JobStatus JobStatus { get; set; }
		public Account Account { get; set;}
		public Account AcceptedBy { get; set; }
	}
}
