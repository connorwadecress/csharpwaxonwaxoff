using UnitConverter.Api.Enums;

namespace UnitConverter.Api
{
    public static class LengthConverter
    {
        //        Unit Metres in 1 of it
        //          m	1
        //km	1000
        //ft	0.3048
        //mi	1609.344

        //switch case statement to convert from one unit to another

        private static double MetresPerUnit(LengthUnit unit)
        {
            // your switch expression: m → 1, km → 1000, ..
            switch (unit)
            {
                case LengthUnit.Metre:
                    return 1;
                case LengthUnit.Kilometre:
                    return 1000;
                case LengthUnit.Foot:
                    return 0.3048;
                case LengthUnit.Mile:
                    return 1609.344;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }

        }

        public static double Convert(double value, LengthUnit from, LengthUnit to)
        {
            // line 1: value into metres  (uses MetresPerUnit(from))
            // line 2: metres into "to"   (uses MetresPerUnit(to))
            double valueInMetres = value * MetresPerUnit(from);
            double valueInToUnit = valueInMetres / MetresPerUnit(to);
        }

    }
}
