
using System;

static class Utilidades
{
    public static string LeerTexto(string mensaje)
    {
        string texto;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine().Trim();
            if (texto == "") Console.WriteLine("El campo no puede estar vacio.");
        } while (texto == "");
        return texto;
    }

    public static int LeerEntero(string mensaje, int min, int max)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out int valor)
                && valor >= min && valor <= max)
                return valor;
            Console.WriteLine($"  [!] Ingrese un numero entero entre {min} y {max}.");
        }
    }

    public static double LeerNota(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine().Replace('.', ',');
            if (double.TryParse(entrada, out double valor)
                && valor >= 0.0 && valor <= 5.0)
                return valor;
            Console.WriteLine("  [!] La nota debe estar entre 0.0 y 5.0.");
        }
    }

    public static void LeerHora(string mensaje, out int minutos, out string horaStr)
    {
        while (true)
        {
            Console.Write(mensaje);
            string[] p = Console.ReadLine().Trim().Split(':');
            if (p.Length == 2
                && int.TryParse(p[0], out int hh)
                && int.TryParse(p[1], out int mm)
                && hh >= 0 && hh <= 23
                && mm >= 0 && mm <= 59)
            {
                minutos = hh * 60 + mm;
                horaStr = $"{hh:00}:{mm:00}";
                return;
            }
            Console.WriteLine("  [!] Formato invalido. Use HH:MM  (ej: 08:30).");
        }
    }

    public static void Separador(int ancho = 44)
        => Console.WriteLine("  " + new string('-', ancho));
}