using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	public class JobPost
	{
		private string jobName { get; set; }
		private int jobId { get; set; }
		private bool jobStatus { get; set; }
		private User postedBy { get; set; }
		private User fufilledBy { get; set; }
	}
}
