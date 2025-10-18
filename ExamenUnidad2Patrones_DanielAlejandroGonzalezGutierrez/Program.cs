using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2Patrones_DanielAlejandroGonzalezGutierrez
{
    class Program
    {
        static void Main(string[] args)
        {
            // Única instancia 
            CentroControlAmbiental centro = CentroControlAmbiental.Instancia;

            Console.WriteLine("====== Sensor ambiente 1 ======");
            Sensor sensor1 = centro.TomarSensorYLeer(valor: "Baja Contaminacion"); 
            centro.FinalizarYLiberar(sensor1);

            Console.WriteLine("====== Sensor Ambiente 2 ======");
            Sensor sensor2 = centro.TomarSensorYLeer(valor: "Alta Contaminacion");
            centro.FinalizarYLiberar(sensor2);


            Console.WriteLine("====== Sensor Ambiente 3 ======");
            Sensor sensor3 = centro.TomarSensorYLeer(valor: "Libre de Contaminacion");
            centro.FinalizarYLiberar(sensor3);


            Console.WriteLine($"\nValidacion de reutilización de objetos de la picina:");
            Console.WriteLine($"  Sensor 1: {sensor1.Id}");
            Console.WriteLine($"  Sensor 2: {sensor2.Id}");
            Console.WriteLine($"  Sensor 3: {sensor3.Id}");

            Console.WriteLine($"\nComprobación de misma instancia sensor 1 y 2: {ReferenceEquals(sensor1, sensor2)}");
            Console.WriteLine($"\nComprobación de misma instancia sensor 3: {ReferenceEquals(sensor2, sensor3)}");

            Console.ReadKey();
        }
    }
}
