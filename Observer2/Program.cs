using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer2
{
    public interface IPublicador
    {
        void RegistrarObservador(IObservador observador);
        void QuitarObservador(IObservador observador);

        void Notificar();
    }

    public interface IObservador
    {
        void Actualizar();
    }

    public class EstacionMetereologica
    {
        public decimal Temperatura { get; private set; }
        public decimal Presion { get; private set; }
        public decimal Humedad { get; private set; }

        public event EventHandler<Tuple<decimal, decimal, decimal>> HaCambiadoElTiempo;

        public void AumentarLaTemperaturaEnGrados(int grados)
        {
            Temperatura = grados + 1;

            Notificar();
        }

        public void Notificar()
        {
            var medidas = new Tuple<decimal, decimal, decimal>(Temperatura, Humedad, Presion);

            if (HaCambiadoElTiempo != null)
                HaCambiadoElTiempo.Invoke(this, medidas);
        }
    }

    public class DispositivoTiempoActual
    {
        // otras métodos y propiedades del dispositivo

        public void ActualizarPantallaDipositivo(object sender, Tuple<decimal, decimal, decimal> medidas)
        {
            var temperatura = medidas.Item1;
            var presion = medidas.Item2;
            var humedad = medidas.Item3;

            Console.WriteLine("Actualiza Dev Tiempo Actual");
            // cosas importantes que hacer con las medidas
        }
    }

    public class DispositivoEstadisticas
    {
        // otras métodos y propiedades del dispositivo

        public void AñadirDatosParaLasEstadisticas(object sender, Tuple<decimal, decimal, decimal> medidas)
        {
            var temperatura = medidas.Item1;
            var presion = medidas.Item2;
            var humedad = medidas.Item3;

            Console.WriteLine("Actualiza Dev Estadisticas");
            // cosas importantes que hacer con las medidas
        }
    }

    public class DispositivoPredictivo
    {
        // otras métodos y propiedades del dispositivo

        public void AñadirDatosDePrediccion(object sender, Tuple<decimal, decimal, decimal> medidas)
        {
            var temperatura = medidas.Item1;
            var presion = medidas.Item2;
            var humedad = medidas.Item3;

            Console.WriteLine("Actualiza Dev Predictive");
            // cosas importantes que hacer con las medidas
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            EstacionMetereologica estacionMetereologica = new EstacionMetereologica();

            DispositivoTiempoActual dispositivoTiempoActual = new DispositivoTiempoActual();
            DispositivoEstadisticas dispositivoEstadisticas = new DispositivoEstadisticas();
            DispositivoPredictivo dispositivoPredictivo = new DispositivoPredictivo();


            estacionMetereologica.HaCambiadoElTiempo += dispositivoTiempoActual.ActualizarPantallaDipositivo;
            estacionMetereologica.HaCambiadoElTiempo += dispositivoEstadisticas.AñadirDatosParaLasEstadisticas;
            estacionMetereologica.HaCambiadoElTiempo += dispositivoPredictivo.AñadirDatosDePrediccion;

            estacionMetereologica.AumentarLaTemperaturaEnGrados(1);

            Console.ReadKey();
        }


    }
}

