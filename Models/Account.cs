﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
	//Stand until I learn ot use how to make an Account
	public class Account
	{
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }
		public int AccountID { get; set; }
		public bool Buisness { get; set; }

		//ref ????
		public List<JobPost> JobPosts { get; set; }
	}
}