using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2Patrones_DanielAlejandroGonzalezGutierrez
{
    sealed class CentroControlAmbiental
    {
        private static CentroControlAmbiental _instancia = null;
        private static readonly object _lock = new object();
        public int SensoresDisponibles => _pool.DisponiblesCount;
        public int SensoresEnUso => _pool.EnUsoCount;

        public static CentroControlAmbiental Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                            _instancia = new CentroControlAmbiental();
                    }
                }
                return _instancia;
            }
        }

        private readonly SensorPool _pool;

        private CentroControlAmbiental()
        {
            
            _pool = new SensorPool(tamanoInicial: 3, maxTamano:3);
        }

        public Sensor TomarSensorYLeer(string valor)
        {
            Sensor s = _pool.Adquirir();
            s.ComenzarLectura(valor);
            return s;
        }
        
        public void FinalizarYLiberar(Sensor sensor)
        {
            if (sensor.Estado != EstadoSensor.EnLectura)
                throw new InvalidOperationException("No se libera un sensor que no está en lectura.");
            _pool.Liberar(sensor);
            Console.WriteLine($"[LIBERADO] Sensor #{sensor.Id} devuelto al pool.\n");
        }

        
    }
}
