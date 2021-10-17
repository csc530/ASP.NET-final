using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	public class JobStatus
	{

		[Key, Display(Name ="Job status")]
		public string Name { get; set; }

		//child ref?
		public List<JobPost> jobPosts { get; set; }
	}
}
