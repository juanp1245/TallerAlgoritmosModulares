using System;
using TallerAlgoritmosModulares;

internal class Program
{
    private static void Main(string[] args)
    {
        TurnosIPS turnoIps = new TurnosIPS();
        SeguimientoNotas seguimientoNotas = new SeguimientoNotas();
        ParqueaderoConjunto parqueaderoConjunto = new ParqueaderoConjunto();

        int seleccion = 0;

        while (seleccion != 4)
        {
            Console.WriteLine("---------------- Menú de sistemas de gestión ----------------");
            Console.WriteLine("Seleccione uno de los siguientes programas:");
            Console.WriteLine("1. Sistema de control de turnos para una IPS");
            Console.WriteLine("2. Sistema de control académico para seguimiento de notas");
            Console.WriteLine("3. Sistema de control de parqueadero para conjunto residencial");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");

            seleccion = Convert.ToInt32(Console.ReadLine());

            while (seleccion < 1 || seleccion > 4)
            {
                Console.WriteLine("Seleccione una opción correcta (1-4):");
                seleccion = Convert.ToInt32(Console.ReadLine());
            }

            switch (seleccion)
            {
                case 1:
                    turnoIps.Ejecutar();
                    break;
                case 2:
                    seguimientoNotas.Ejecutar();
                    break;
                case 3:
                    parqueaderoConjunto.Ejecutar();
                    break;
                case 4:
                    Console.WriteLine("Programa finalizado.");
                    break;
            }
        }
    }
}