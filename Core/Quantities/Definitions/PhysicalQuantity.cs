﻿namespace Core.Common.Quantities.Definitions
{
	using ArgumentMust;
	using Notification;

	public abstract class PhysicalQuantity<TPhysicalQuantity> : Bindable, IPhysicalQuantity<TPhysicalQuantity>
		where TPhysicalQuantity : PhysicalQuantity<TPhysicalQuantity>, new()
	{
		protected PhysicalQuantity(double value, Unit<TPhysicalQuantity> unit)
		{
			ArgumentMust.NotBeNull(() => unit);

			Value = value;
			Unit = unit;
		}

		public double ValueInBaseUnit => Value * Unit.FactorToBaseUnit;

		public abstract BaseUnit<TPhysicalQuantity> BaseUnit { get; }

		public double Value
		{
			get => Get<double>();
			set => Set(value);
		}

		public string UnitSymbol => Unit.Symbol;

		public Unit<TPhysicalQuantity> Unit
		{
			get => Get<Unit<TPhysicalQuantity>>();
			private set
			{
				if (Set(value))
				{
					OnPropertyChanged(nameof(UnitSymbol));
				}
			}
		}

		public TPhysicalQuantity In<TUnit>() where TUnit : Unit<TPhysicalQuantity>, new()
		{
			var unit = new TUnit();
			return new TPhysicalQuantity
			{
				Value = ValueInBaseUnit / unit.FactorToBaseUnit,
				Unit = unit
			};
		}

		public TPhysicalQuantity InBaseUnit()
		{
			return new TPhysicalQuantity
			{
				Value = Value * Unit.FactorToBaseUnit,
				Unit = BaseUnit
			};
		}

		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, (PhysicalQuantity<TPhysicalQuantity>)obj);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode() * Unit.GetHashCode();
		}

		public static bool operator ==(PhysicalQuantity<TPhysicalQuantity> leftHandSide, TPhysicalQuantity rightHandSide)
		{
			ArgumentMust.NotBeNull(() => leftHandSide);
			ArgumentMust.NotBeNull(() => rightHandSide);

			return leftHandSide.InBaseUnit().Value == rightHandSide.InBaseUnit().Value;
		}

		public static bool operator !=(PhysicalQuantity<TPhysicalQuantity> leftHandSide, TPhysicalQuantity rightHandSide)
		{
			return !(leftHandSide == rightHandSide);
		}

		public static TPhysicalQuantity operator +(PhysicalQuantity<TPhysicalQuantity> leftHandSide, TPhysicalQuantity rightHandSide)
		{
			ArgumentMust.NotBeNull(() => leftHandSide);
			ArgumentMust.NotBeNull(() => rightHandSide);

			return new TPhysicalQuantity
			{
				Value = leftHandSide.ValueInBaseUnit + rightHandSide.InBaseUnit().Value,
				Unit = leftHandSide.BaseUnit
			};
		}

		public static TPhysicalQuantity operator -(PhysicalQuantity<TPhysicalQuantity> leftHandSide, TPhysicalQuantity rightHandSide)
		{
			ArgumentMust.NotBeNull(() => leftHandSide);
			ArgumentMust.NotBeNull(() => rightHandSide);

			return new TPhysicalQuantity
			{
				Value = leftHandSide.ValueInBaseUnit - rightHandSide.InBaseUnit().Value,
				Unit = leftHandSide.BaseUnit
			};
		}

		public static double operator /(PhysicalQuantity<TPhysicalQuantity> leftHandSide, TPhysicalQuantity rightHandSide)
		{
			ArgumentMust.NotBeNull(() => leftHandSide);
			ArgumentMust.NotBeNull(() => rightHandSide);

			return leftHandSide.ValueInBaseUnit / rightHandSide.InBaseUnit().Value;
		}

		public static TPhysicalQuantity operator *(PhysicalQuantity<TPhysicalQuantity> leftHandSide, double rightHandSide)
		{
			ArgumentMust.NotBeNull(() => leftHandSide);

			return new TPhysicalQuantity
			{
				Value = leftHandSide.Value * rightHandSide,
				Unit = leftHandSide.Unit
			};
		}

		public static TPhysicalQuantity operator *(double leftHandSide, PhysicalQuantity<TPhysicalQuantity> rightHandSide)
		{
			return rightHandSide * leftHandSide;
		}

		public static TPhysicalQuantity operator /(PhysicalQuantity<TPhysicalQuantity> leftHandSide, double rightHandSide)
		{
			ArgumentMust.NotBeNull(() => leftHandSide);
			ArgumentMust.BeGreater(() => rightHandSide, 0.0);

			return new TPhysicalQuantity
			{
				Value = leftHandSide.ValueInBaseUnit / rightHandSide,
				Unit = leftHandSide.BaseUnit
			};
		}
	}
}