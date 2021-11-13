using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASPFinal.Models
{
	//Stand until I learn ot use how to make an Account
	public class Account
	{
		public int AccountId { get; set; }
		[Required, Display(Name = "Associated account")]
		public string UserId { get; set; }
		[Required(AllowEmptyStrings = false), Display(Name = "Name")]
		public string Name { get; set; }
		public bool Buisness { get; set; }
		[Required(AllowEmptyStrings = false), MaxLength(10000)]
		public string Description { get; set; }
		//children
		[InverseProperty("Account")]
		public List<JobPost> JobPosts { get; set; }
		[InverseProperty("AcceptedBy")]
		public List<JobPost> AcceptedJobs { get; set; }
		
	}
}