using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2Patrones_DanielAlejandroGonzalezGutierrez
{
    class SensorPool
    {
        private readonly Stack<Sensor> _disponibles = new Stack<Sensor>();
        private readonly Stack<Sensor> _enUso = new Stack<Sensor>();
        private readonly object _lock = new object();
        private readonly int _maxTamano;

        public int DisponiblesCount { get { lock (_lock) return _disponibles.Count; } }
        public int EnUsoCount { get { lock (_lock) return _enUso.Count; } }

        public SensorPool(int tamanoInicial, int maxTamano)
        {
            _maxTamano = maxTamano;
            for (int i = 0; i < tamanoInicial; i++)
                _disponibles.Push(new Sensor());
        }

        public Sensor Adquirir()
        {
            lock (_lock)
            {
                Sensor s;
                if (DisponiblesCount > 0)
                {
                    s = _disponibles.Pop();
                }
                else
                {
                    int totalActual = DisponiblesCount + EnUsoCount;
                    if (totalActual >= _maxTamano)
                        throw new InvalidOperationException("Se llego al Limite .");                   

                    s = new Sensor();
                }

                s.EnUso = true;
                _enUso.Push(s);
                return s;
            }
        }

        public void Liberar(Sensor sensor)
        {
            if (sensor == null) return;

            lock (_lock)
            {
               
                bool EncontrarYEliminar()
                {
                    if (EnUsoCount == 0) return false;

                    Sensor top = _enUso.Pop();
                    if (top == sensor)
                        return true;

                    bool encontradoEnResto = EncontrarYEliminar();
                    _enUso.Push(top);
                    return encontradoEnResto;
                }

                bool encontrado = EncontrarYEliminar();
                if (!encontrado) return; 

                sensor.Reset();
                _disponibles.Push(sensor);
            }
        }
    }
}
