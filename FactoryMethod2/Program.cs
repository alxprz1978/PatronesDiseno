using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod2
{
    public abstract class CombustibleVehiculo
    {
        public abstract int CuantoOctanaje();

        public string OperacionComun()
        {
            return "El octanaje de este combistible es:";
        }
    }
    
    public class GasolinaMagna : CombustibleVehiculo
    {
        public override int CuantoOctanaje()
        {
            return 87;
        }
    }

    public class GasolinaPremium : CombustibleVehiculo
    {
        public override int CuantoOctanaje()
        {
            return 92;
        }
    }

    public class Vehiculo
    {
        public const int MAGNA = 1;
        public const int PREMIUM = 2;

        public static CombustibleVehiculo VehiculoUsa(int tipo)
        {
            switch(tipo)
            {
                case MAGNA:
                    return new GasolinaMagna();
                case PREMIUM:
                    return new GasolinaPremium();
                default:
                    return null;
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            CombustibleVehiculo oCombustible = Vehiculo.VehiculoUsa(Vehiculo.MAGNA);
            Console.WriteLine(oCombustible.OperacionComun());
            Console.WriteLine(oCombustible.CuantoOctanaje());

            CombustibleVehiculo oCombustible2 = Vehiculo.VehiculoUsa(Vehiculo.PREMIUM);
            Console.WriteLine(oCombustible2.OperacionComun());
            Console.WriteLine(oCombustible2.CuantoOctanaje());

            Console.ReadKey();

        }
    }
}
