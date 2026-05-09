using TallerAlgoritmosModulares;

internal class Program
{
    private static void Main(string[] args)
    {
        TurnosIPS turnoIps = new TurnosIPS();
        SeguimientoNotas seguimientoNotas = new SeguimientoNotas();
        ParqueaderoConjunto parqueaderoConjunto = new ParqueaderoConjunto();

        Console.WriteLine("---------------- Menú de sistemas de gestión ----------------");
        Console.WriteLine("Seleccione uno de los siguientes programas:");
        Console.WriteLine("1. Sistema de control de turnos para una IPS\n" +
            "2. Sistema de control académico para seguimiento de notas\n" +
            "3. Sistema de control de parqueadero para conjunto residencial\n" +
            "4. Salir");

        int seleccion = Convert.ToInt32(Console.ReadLine());

        while (seleccion < 1 || seleccion > 4)
        {
            Console.WriteLine("Seleccione una opción correcta:");
            seleccion = Convert.ToInt32(Console.ReadLine());
        }

        if (seleccion != 4)
        {
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
                default:
                    break;
            }
        }
    }
}