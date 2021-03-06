namespace Core.Common.Quantities.LengthQuantity
{
	using Definitions;

	public sealed class Meter : BaseUnit<Length>
	{
		public static Meter Instance { get; } = new Meter();

		public override string Symbol => "m";
	}
}