using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2Patrones_DanielAlejandroGonzalezGutierrez
{
    class Sensor
    {
        public int Id { get; private set; }
        public bool EnUso { get; set; }
        public EstadoSensor Estado { get; private set; }
        public string Valor { get; private set; } 

        private static int _contador = 1;

        public Sensor()
        {
            Id = _contador++;
            Reset();
        }

        public void ComenzarLectura(string valor)
        {
            Valor = valor;
            Estado = EstadoSensor.EnLectura;
            Console.WriteLine($"[LECTURA] Sensor #{Id} en {Estado}. Valor: {Valor}");
        }

        public void Reset()
        {
            Valor = "";
            Estado = EstadoSensor.EnPiscina;
            EnUso = false;
        }
    }
    enum EstadoSensor
    {
        EnPiscina,
        EnLectura
    }
}
