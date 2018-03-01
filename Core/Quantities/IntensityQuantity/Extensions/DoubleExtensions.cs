﻿namespace Core.Common.Quantities.IntensityQuantity.Extensions
{
	public static class DoubleExtensions
	{
		public static Intensity WattsPerSquareMeter(this double value)
		{
			return new Intensity(value, WattPerSquareMeter.Instance);
		}

		public static Intensity WattsPerSquareCentimeter(this double value)
		{
			return new Intensity(value, WattPerSquareCentimeter.Instance);
		}
	}
}