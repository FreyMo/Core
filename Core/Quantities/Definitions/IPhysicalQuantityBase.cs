namespace Core.Common.Quantities.Definitions
{
	public interface IPhysicalQuantityBase
	{
		double Value { get; }

		string UnitSymbol { get; }
	}
}