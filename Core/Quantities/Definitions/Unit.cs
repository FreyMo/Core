﻿namespace Core.Common.Quantities.Definitions
{
	public abstract class Unit<TPhysicalQuantity> : IUnitBase
		where TPhysicalQuantity : IPhysicalQuantity<TPhysicalQuantity>
	{
		public abstract double FactorToBaseUnit { get; }

		public abstract string Symbol { get; }
	}
}