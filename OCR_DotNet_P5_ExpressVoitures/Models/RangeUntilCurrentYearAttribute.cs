﻿using System.ComponentModel.DataAnnotations;

namespace OCR_DotNet_P5_ExpressVoitures.Models
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public class RangeUntilCurrentYearAttribute : RangeAttribute
	{
		public RangeUntilCurrentYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
		{
		}
	}
}
