using System;

namespace Proyecto_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            // constructor de la clase Metodos.
            Metodos ConstructorMetodos = new Metodos(); 
            int Seleccion;


            do // Hacemos uso de un do...While para poner el programa en un bucle para que se ejecute cuantas veces queramos.
            {
                ConstructorMetodos.Formulario();
                ConstructorMetodos.Calcular();
                ConstructorMetodos.Cuadro();
                ConstructorMetodos.CrearTabla();
                ConstructorMetodos.GenerarTabla();
                Console.WriteLine("|---------------------------------------------------------------------------------|");
                Console.WriteLine("|¿Desea Continuar? Pulse 1 para seguir ejecutando el programa, pulse 2 para salir.|");
                Console.WriteLine("|---------------------------------------------------------------------------------|");
                Seleccion = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= 60; i++) //vamos a usar un for para limpiar la consola despues de cada eleccion.
                {
                    Console.WriteLine(" ");
                }

            } while (Seleccion != 2);



        }
    }
}
