using System;

static class Caso4Parqueadero
{

    const int MAX = 40;


    static string[] placa = new string[MAX];
    static string[] torre = new string[MAX];
    static string[] apto = new string[MAX];
    static int[] horaIng = new int[MAX];    
    static string[] horaIngStr = new string[MAX];
    static int[] horaSal = new int[MAX];     
    static string[] horaSalStr = new string[MAX];
    static string[] tipo = new string[MAX];
    static int total = 0;


    static int PlacaDentro(string p)
    {
        for (int i = 0; i < total; i++)
            if (placa[i] == p && horaSal[i] == -1) return i;
        return -1;
    }

    static string MinutosATexto(int min)
        => $"{min / 60}h {min % 60:00}m";


    static int IndiceMayorPermanencia()
    {
        int idx = -1;
        for (int i = 0; i < total; i++)
        {
            if (horaSal[i] == -1) continue;
            int perm = horaSal[i] - horaIng[i];
            if (idx == -1 || perm > (horaSal[idx] - horaIng[idx]))
                idx = i;
        }
        return idx;
    }

    static void RegistrarIngreso()
    {
        if (total >= MAX)
        {
            Console.WriteLine($"\n  [!] Cupo maximo alcanzado ({MAX} ingresos).");
            return;
        }

        Console.WriteLine("\n  --- Registrar Ingreso ---");
        string p = Utilidades.LeerTexto("  Placa: ").ToUpper();

        if (PlacaDentro(p) != -1)
        {
            Console.WriteLine("  [!] Esa placa ya se encuentra dentro del parqueadero.");
            return;
        }

        placa[total] = p;
        torre[total] = Utilidades.LeerTexto("  Torre visitada: ");
        apto[total] = Utilidades.LeerTexto("  Apartamento: ");
        Utilidades.LeerHora("  Hora de ingreso (HH:MM): ",
                            out horaIng[total], out horaIngStr[total]);
        tipo[total] = LeerTipoVehiculo();
        horaSal[total] = -1;
        horaSalStr[total] = "--:--";

        Console.WriteLine($"  [OK] Ingreso de {p} registrado a las {horaIngStr[total]}.");
        total++;
    }

    static void RegistrarSalida()
    {
        Console.WriteLine("\n  --- Registrar Salida ---");
        string p = Utilidades.LeerTexto("  Placa del vehiculo que sale: ").ToUpper();
        int idx = PlacaDentro(p);

        if (idx == -1)
        {
            Console.WriteLine("  [!] La placa no se encuentra en el parqueadero.");
            return;
        }

        Utilidades.LeerHora("  Hora de salida (HH:MM): ", out int minSal, out string strSal);

        if (minSal < horaIng[idx])
        {
            Console.WriteLine("  [!] La hora de salida no puede ser anterior a la de ingreso.");
            return;
        }

        horaSal[idx] = minSal;
        horaSalStr[idx] = strSal;
        int perm = minSal - horaIng[idx];
        Console.WriteLine($"  [OK] Salida registrada. Permanencia: {MinutosATexto(perm)}");
    }

    static void MostrarListado()
    {
        if (total == 0) { Console.WriteLine("\n  [!] No hay registros."); return; }

        Console.WriteLine("\n  --- Listado de Ingresos ---");
        Console.WriteLine($"  {"Placa",-10} {"Tipo",-11} {"Torre",-7} " +
                          $"{"Apto",-8} {"Ingreso",-9} {"Salida",-9} Permanencia");
        Console.WriteLine("  " + new string('-', 72));

        for (int i = 0; i < total; i++)
        {
            string perm = horaSal[i] == -1
                ? "Dentro"
                : MinutosATexto(horaSal[i] - horaIng[i]);

            Console.WriteLine($"  {placa[i],-10} {tipo[i],-11} {torre[i],-7} " +
                              $"{apto[i],-8} {horaIngStr[i],-9} " +
                              $"{horaSalStr[i],-9} {perm}");
        }
    }

    static void ConteoPorTipo()
    {
        if (total == 0) { Console.WriteLine("\n  [!] No hay registros."); return; }

        int carros = 0, motos = 0, bicis = 0;
        for (int i = 0; i < total; i++)
        {
            if (tipo[i] == "Carro") carros++;
            else if (tipo[i] == "Moto") motos++;
            else bicis++;
        }

        Console.WriteLine("\n  --- Ingresos por Tipo de Vehiculo ---");
        Console.WriteLine($"  Carro     : {carros}");
        Console.WriteLine($"  Moto      : {motos}");
        Console.WriteLine($"  Bicicleta : {bicis}");
    }

    static void MostrarMayorPermanencia()
    {
        int idx = IndiceMayorPermanencia();
        if (idx == -1)
        {
            Console.WriteLine("\n  [!] Aun no hay vehiculos que hayan salido.");
            return;
        }
        int perm = horaSal[idx] - horaIng[idx];
        Console.WriteLine($"\n  Mayor permanencia: {placa[idx]} " +
                          $"({tipo[idx]}) — {MinutosATexto(perm)}");
    }

    static string LeerTipoVehiculo()
    {
        Console.WriteLine("  Tipos: 1-Carro  2-Moto  3-Bicicleta");
        while (true)
        {
            Console.Write("  Seleccione tipo: ");
            switch (Console.ReadLine().Trim())
            {
                case "1": return "Carro";
                case "2": return "Moto";
                case "3": return "Bicicleta";
                default: Console.WriteLine("  [!] Opcion invalida."); break;
            }
        }
    }

    public static void Ejecutar()
    {
        bool volver = false;
        while (!volver)
        {
 
            Console.WriteLine("  CASO 4 - Control de Parqueadero");

            Console.WriteLine("  1. Registrar ingreso");
            Console.WriteLine("  2. Registrar salida");
            Console.WriteLine("  3. Ver listado de ingresos");
            Console.WriteLine("  4. Conteo por tipo de vehiculo");
            Console.WriteLine("  5. Vehiculo con mayor permanencia");
            Console.WriteLine("  0. Volver al menu principal");
            Console.Write("  Opcion: ");

            switch (Console.ReadLine())
            {
                case "1": RegistrarIngreso(); break;
                case "2": RegistrarSalida(); break;
                case "3": MostrarListado(); break;
                case "4": ConteoPorTipo(); break;
                case "5": MostrarMayorPermanencia(); break;
                case "0": volver = true; break;
                default: Console.WriteLine("  [!] Opcion invalida."); break;
            }
        }
    }
}