using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	public class JobStatus
	{
		public int JobStatusId { get; set;}
		[Display(Name ="Status")]
		public string Name { get; set; }

		//child ref?
		public List<JobPost> JobPosts { get; set; }
	}
}
