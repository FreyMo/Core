namespace Core.Common.Quantities.Definitions
{
	public abstract class BaseUnit<TPhysicalQuantity> : Unit<TPhysicalQuantity>
		where TPhysicalQuantity : IPhysicalQuantity<TPhysicalQuantity>
	{
		public sealed override double FactorToBaseUnit => 1;
	}
}