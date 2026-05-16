using System;

namespace TallerAlgoritmosModulares
{
    internal class SeguimientoNotas
    {
        int maxEstudiantes = 25;
        int contadorEstudiantes = 0;

        string[] codigos = new string[25];
        string[] nombres = new string[25];
        double[] asistencias = new double[25];

        double[,] notasParciales = new double[25, 3];

        public void Ejecutar()
        {
            int seleccion = 0;

            while (seleccion != 6)
            {
                Console.WriteLine("\n---------------- Sistema de Control Académico ----------------");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Registrar estudiantes");
                Console.WriteLine("2. Calcular definitiva y mostrar estado");
                Console.WriteLine("3. Mostrar promedio general del grupo");
                Console.WriteLine("4. Identificar mejor y peor promedio");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Opción: ");

                seleccion = Convert.ToInt32(Console.ReadLine());

                while (seleccion < 1 || seleccion > 6)
                {
                    Console.WriteLine("Seleccione una opción correcta (1-6):");
                    seleccion = Convert.ToInt32(Console.ReadLine());
                }

                switch (seleccion)
                {
                    case 1:
                        RegistrarEstudiantes();
                        break;
                    case 2:
                        CalcularDefinitivaYEstado();
                        break;
                    case 3:
                        MostrarPromedioGrupo();
                        break;
                    case 4:
                        IdentificarExtremos();
                        break;
                    case 5:
                        Console.WriteLine("Regresando al menú principal...");
                        break;
                }
            }
        }

        private void RegistrarEstudiantes()
        {
            Console.WriteLine("\n--- Registro de Estudiante ---");

            if (contadorEstudiantes >= maxEstudiantes)
            {
                Console.WriteLine("Error: No hay cupos disponibles. Se ha alcanzado el límite de 25 estudiantes.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el código del estudiante: ");
            codigos[contadorEstudiantes] = Console.ReadLine();

            Console.Write("Ingrese el nombre completo: ");
            nombres[contadorEstudiantes] = Console.ReadLine();

            double asistencia = -1;
            while (asistencia < 0 || asistencia > 100)
            {
                Console.Write("Ingrese el porcentaje de asistencia (0 a 100): ");
                asistencia = Convert.ToDouble(Console.ReadLine());

                if (asistencia < 0 || asistencia > 100)
                {
                    Console.WriteLine("Porcentaje inválido. Debe estar entre 0 y 100.");
                }
            }
            asistencias[contadorEstudiantes] = asistencia;

            for (int c = 0; c < 3; c++)
            {
                double nota = -1;

                while (nota < 0.0 || nota > 5.0)
                {
                    Console.Write($"Ingrese la nota parcial {c + 1} (0.0 a 5.0): ");
                    nota = Convert.ToDouble(Console.ReadLine());

                    if (nota < 0.0 || nota > 5.0)
                    {
                        Console.WriteLine("Nota inválida. La calificación debe estar en el rango de 0.0 a 5.0.");
                    }
                }

                notasParciales[contadorEstudiantes, c] = nota;
            }

            Console.WriteLine("\nEstudiante y notas registrados correctamente.");
            contadorEstudiantes++;

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void CalcularDefinitivaYEstado()
        {
            Console.WriteLine("\n--- Definitivas y Estados ---");

            if (contadorEstudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados en el sistema para calcular definitivas.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("| {0,-10} | {1,-20} | {2,-7} | {3,-7} | {4,-7} | {5,-10} | {6,-9} |",
                "Código", "Nombre", "Nota 1", "Nota 2", "Nota 3", "Definitiva", "Estado"));
            Console.WriteLine("--------------------------------------------------------------------------------");

            for (int i = 0; i < contadorEstudiantes; i++)
            {
                double sumaNotas = 0.0;

                for (int c = 0; c < 3; c++)
                {
                    sumaNotas += notasParciales[i, c];
                }

                double definitiva = sumaNotas / 3.0;
                string estado;

                if (definitiva >= 3.0)
                {
                    estado = "Aprobado";
                }
                else
                {
                    estado = "Reprueba";
                }

                Console.WriteLine(string.Format("| {0,-10} | {1,-20} | {2,-7:F2} | {3,-7:F2} | {4,-7:F2} | {5,-10:F2} | {6,-9} |",
                    codigos[i],
                    nombres[i],
                    notasParciales[i, 0],
                    notasParciales[i, 1],
                    notasParciales[i, 2],
                    definitiva,
                    estado));
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarPromedioGrupo()
        {
            Console.WriteLine("\n--- Promedio General del Grupo ---");

            if (contadorEstudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados en el sistema para calcular un promedio.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            double sumaDefinitivasGrupo = 0.0;

            for (int i = 0; i < contadorEstudiantes; i++)
            {
                double sumaNotasEstudiante = 0.0;

                for (int c = 0; c < 3; c++)
                {
                    sumaNotasEstudiante += notasParciales[i, c];
                }

                double definitivaEstudiante = sumaNotasEstudiante / 3.0;

                sumaDefinitivasGrupo += definitivaEstudiante;
            }

            double promedioGeneral = sumaDefinitivasGrupo / contadorEstudiantes;

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total estudiantes evaluados: {contadorEstudiantes}");
            Console.WriteLine($"Promedio general del grupo:  {promedioGeneral:F2}");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void IdentificarExtremos()
        {
            Console.WriteLine("\n--- Mejor y Peor Promedio ---");

            if (contadorEstudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados en el sistema para evaluar extremos.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            double sumaNotasPrimerEstudiante = 0.0;
            for (int c = 0; c < 3; c++)
            {
                sumaNotasPrimerEstudiante += notasParciales[0, c];
            }

            double mejorPromedio = sumaNotasPrimerEstudiante / 3.0;
            double peorPromedio = sumaNotasPrimerEstudiante / 3.0;

            int indiceMejor = 0;
            int indicePeor = 0;

            for (int i = 1; i < contadorEstudiantes; i++)
            {
                double sumaNotasActual = 0.0;
                for (int c = 0; c < 3; c++)
                {
                    sumaNotasActual += notasParciales[i, c];
                }

                double promedioActual = sumaNotasActual / 3.0;

                if (promedioActual > mejorPromedio)
                {
                    mejorPromedio = promedioActual;
                    indiceMejor = i;
                }

                if (promedioActual < peorPromedio)
                {
                    peorPromedio = promedioActual;
                    indicePeor = i;
                }
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("MEJOR PROMEDIO");
            Console.WriteLine($"Código:    {codigos[indiceMejor]}");
            Console.WriteLine($"Nombre:    {nombres[indiceMejor]}");
            Console.WriteLine($"Promedio:  {mejorPromedio:F2}");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("PEOR PROMEDIO");
            Console.WriteLine($"Código:    {codigos[indicePeor]}");
            Console.WriteLine($"Nombre:    {nombres[indicePeor]}");
            Console.WriteLine($"Promedio:  {peorPromedio:F2}");
            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
