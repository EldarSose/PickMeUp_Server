﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Gender
	{
		[Key]
		public int genderId { get; set; }
		public string? description { get; set; }
		public bool? isDeleted { get; set; }
	}
}
