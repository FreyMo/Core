﻿namespace Core.Common.Quantities.FrequencyQuantity.Extensions
{
	using System;

	public static class IntegerExtensions
	{
		public static Frequency Hertz(this int value)
		{
			return Convert.ToDouble(value).Hertz();
		}

		public static Frequency KiloHertz(this int value)
		{
			return Convert.ToDouble(value).KiloHertz();
		}

		public static Frequency MegaHertz(this int value)
		{
			return Convert.ToDouble(value).MegaHertz();
		}
	}
}