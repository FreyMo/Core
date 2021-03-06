﻿namespace Core.Common.Quantities.VelocityQuantity.Extensions
{
	using System;

	public static class IntegerExtensions
	{
		public static Velocity MetersPerSecond(this int value)
		{
			return Convert.ToDouble(value).MetersPerSecond();
		}

	    public static Velocity KilometersPerHour(this int value)
	    {
	        return Convert.ToDouble(value).KilometersPerHour();
	    }

	    public static Velocity MillimetersPerSecond(this int value)
	    {
	        return Convert.ToDouble(value).MillimetersPerSecond();
	    }
    }
}