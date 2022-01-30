using System;

namespace Packt.Shared
{
    public class BussinessClassPassenger
    {
        public override string ToString()
        {
            return $"Bussiness Class";
        }
    }

    public class FirstClassPassenger
    {
        public int AirMiles { get; set; }
        public override string ToString()
        {
            return $"First Class with {AirMiles:N0} air miles";
        }
    }

    public class CoachClassPassenger
    {
        public double CarryOnKG { get; set; }
        public override string ToString()
        {
            return $"Coach Class with {CarryOnKG:N2} KG carry on";
        }
    }
}
