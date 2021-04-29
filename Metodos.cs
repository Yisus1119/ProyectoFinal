using System;

namespace Proyecto_Final
{
    class Metodos
    {

        class Atributos //uso de los atributos con sus respectivos tipos de datos.
        {
            public double MontoPrestamo, TasaPorcentaje, ValorCuota, ValorCuotaFinal, ElevarPotencia, ResultadoPotencia,
            ResultadoCuota, CapitalMensual, InteresMensual, ConversionTasa, RedondearCuota, RedondearInteres, RedondearCapital, MontoRestante;


        }

        public int Plazo, Fila;

        Atributos UA = new Atributos(); //crearemos y usaremos un constructor para poder utilizar los atributos, este se llamará UA como abreviacion de: UsarAtributos.

        public void Formulario() //Este es el formulario que nos pedirá nuestros datos.
        {
            Console.WriteLine("Bienvenido a la calculadora de prestamos");

            Console.WriteLine("1. Ingrese el monto de su prestamo: ");
            UA.MontoPrestamo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("2. Ingrese la tasa porcentual de su prestamo sin el (%): ");
            UA.TasaPorcentaje = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("3. Ingrese el plazo de la cuotas (en meses): ");
            Plazo = Convert.ToInt32(Console.ReadLine());
        }


        public void Calcular() //Aquí es donde se encuentran las fórmulas para calcular la tasa porcentual y nuestra cuota.
        {

            UA.ConversionTasa = (UA.TasaPorcentaje / 12) / 100; // Convertimos la tasa anual a mensual.

            UA.ValorCuota = UA.ConversionTasa * UA.MontoPrestamo; // Multiplicamos la tasa ya convertida a mensual por el monto del préstamo.

            UA.ValorCuotaFinal = (1 + UA.ConversionTasa); // sumamos la tasa mensual más 1.

            UA.ElevarPotencia = Math.Pow(UA.ValorCuotaFinal, -Plazo); // Elevamos el resultado anterior y lo restamos con el plazo del préstamo.

            UA.ResultadoPotencia = 1 - UA.ElevarPotencia; // luego le restamos 1.

            UA.ResultadoCuota = UA.ValorCuota / UA.ResultadoPotencia; // dividimos la segunda fórmula (UA.ValorCuota) con el resultado de la operación anterior (UA.ResultadoPotencia). Obteniendo el valor total de la cuota.
            UA.RedondearCuota = Math.Round(UA.ResultadoCuota, 2);

        }


        public void Cuadro() // Aquí aparecerá la información de nuestro préstamo.
        {
            Console.WriteLine();
            Console.WriteLine("\t|******************************|");
            Console.WriteLine("\t|CARACTERISTICAS DEL PRESTAMO  |");
            Console.WriteLine("\t|                               ");
            Console.WriteLine("\t| Monto del Prestamo en $RD: " + UA.MontoPrestamo);
            Console.WriteLine("\t| Tasa Anual: " + UA.TasaPorcentaje + " %");
            Console.WriteLine("\t| Plazo: " + Plazo + " meses");
            Console.WriteLine("\t| Cuota: RD$" + UA.RedondearCuota);
            Console.WriteLine("\t|                              |");
            Console.WriteLine("\t|******************************|");

        }


        public void CrearTabla() // Aquí es donde le daremos formato a nuestra tabla amortizadora.
        {
            Console.WriteLine();
            Fila = 1;
            Console.WriteLine();
            Console.WriteLine("\t|*******************************************************************************************************************************|");
            Console.WriteLine("\t|                                                                                                                               |");
            Console.WriteLine("\t|\t\t\t\t\t\t\tTABLA AMORTIZADORA                                                      |");
            Console.WriteLine("\t|                                                                                                                               |");
            Console.WriteLine("\t|*******************************************************************************************************************************|");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\tPago \t");
            Console.Write("\tFecha de Pago \t\t");
            Console.Write("Cuota \t\t");
            Console.Write("\tInteres \t\t");
            Console.Write("Capital\t\t");
            Console.Write("\tMonto restante \t");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("\t|*******************************************************************************************************************************|");
            Console.WriteLine();
            Console.Write("\t");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t");

        }

        DateTime Fecha = DateTime.Now; // Creamos un datetime con el nombre de fecha, que nos serivirá para crear las fechas de pago.

        public void GenerarTabla() // Aquí es donde generaremos nuesta tabla amortizadora.
        {
            for (int i = 1; i <= Plazo; i++)
            {
                Console.Write("\t{0}\t\t", Fila);

                // crearemos la fecha de pago
                Console.Write(Fecha.AddMonths(i).ToString("dd-MM-yyyy"));
                Console.Write("\t");

                //aqui aparecera la cuota mensual
                Console.Write("\t{0}\t", UA.RedondearCuota);


                // Aquí calcularemos el interes mensual.
                UA.InteresMensual = UA.MontoPrestamo * UA.ConversionTasa;
                UA.RedondearInteres = Math.Round(UA.InteresMensual, 2);

                Console.Write("\t\t{0}\t", UA.RedondearInteres);

                // Aquí calcularemos el capital mensual.
                UA.CapitalMensual = UA.RedondearCuota - UA.InteresMensual;
                UA.RedondearCapital = Math.Round(UA.CapitalMensual, 2);

                Console.Write("\t\t{0}\t", UA.RedondearCapital);

                //Aquí se irá calculando el monto de los prestamos.
                UA.MontoPrestamo = UA.MontoPrestamo - UA.CapitalMensual;
                UA.MontoRestante = Math.Round(UA.MontoPrestamo, 2);

                Console.Write("\t\t{0}\t", UA.MontoRestante);

                Fila = Fila + 1;
                Console.WriteLine();








            }

        }


    }

}