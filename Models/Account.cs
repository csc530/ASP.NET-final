using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ASPFinal.Models
{
	//Stand until I learn ot use how to make an Account
	public class Account
	{
		public int AccountId { get; set;}
		public string Name { get; set; }
		public bool Buisness { get; set;}
		//children
		public List<JobPost> JobPosts { get; set;}
	}
}