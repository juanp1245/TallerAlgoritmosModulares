using System;

namespace TallerAlgoritmosModulares
{
    internal class TurnosIPS
    {
        int maxPacientes = 30;
        int contadorPacientes = 0;

        int[] documentos = new int[30];
        string[] nombres = new string[30];
        int[] edades = new int[30];
        string[] tiposAtencion = new string[30];
        int[] prioridades = new int[30];

        public void Ejecutar()
        {
            int seleccion = 0;

            while (seleccion != 6)
            {
                Console.WriteLine("\n---------------- Sistema de control de turnos para una IPS ----------------");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Registrar pacientes");
                Console.WriteLine("2. Mostrar listado general");
                Console.WriteLine("3. Buscar pacientes por documento");
                Console.WriteLine("4. Mostrar cuántos pacientes hay por tipo de atención");
                Console.WriteLine("5. Identificar el paciente con mayor prioridad");
                Console.WriteLine("6. Volver al menú principal");
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
                        RegistrarPacientes();
                        break;
                    case 2:
                        MostrarListado();
                        break;
                    case 3:
                        BuscarPacienteDocumento();
                        break;
                    case 4:
                        MostrarPacienteTipoAtencion();
                        break;
                    case 5:
                        PacienteMayorPrioridad();
                        break;
                    case 6:
                        Console.WriteLine("Regresando al menú principal...");
                        break;
                }
            }
        }

        private void RegistrarPacientes()
        {
            Console.WriteLine("\n--- Registro de Paciente ---");

            if (contadorPacientes >= maxPacientes)
            {
                Console.WriteLine("Error: No hay cupos disponibles. Se ha alcanzado el límite máximo de 30 pacientes.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el número de documento: ");
            documentos[contadorPacientes] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el nombre completo: ");
            nombres[contadorPacientes] = Console.ReadLine();

            Console.Write("Ingrese la edad: ");
            edades[contadorPacientes] = Convert.ToInt32(Console.ReadLine());

            int opcionAtencion = 0;
            while (opcionAtencion < 1 || opcionAtencion > 3)
            {
                Console.WriteLine("Seleccione el tipo de atención:");
                Console.WriteLine("1. Urgencias");
                Console.WriteLine("2. Consulta General");
                Console.WriteLine("3. Prioritaria");
                Console.Write("Opción (1-3): ");
                opcionAtencion = Convert.ToInt32(Console.ReadLine());

                if (opcionAtencion < 1 || opcionAtencion > 3)
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                }
            }
            if (opcionAtencion == 1)
            {
                tiposAtencion[contadorPacientes] = "Urgencias";
            }
            else if (opcionAtencion == 2)
            {
                tiposAtencion[contadorPacientes] = "Consulta General";
            }
            else
            {
                tiposAtencion[contadorPacientes] = "Prioritaria";
            }

            int prioridad = 0;
            while (prioridad < 1 || prioridad > 5)
            {
                Console.Write("Ingrese el nivel de prioridad (1 al 5): ");
                prioridad = Convert.ToInt32(Console.ReadLine());

                if (prioridad < 1 || prioridad > 5)
                {
                    Console.WriteLine("Nivel no válido. La prioridad debe estar en el rango de 1 a 5.");
                }
            }
            prioridades[contadorPacientes] = prioridad;

            Console.WriteLine("\nPaciente registrado correctamente.");
            contadorPacientes++;

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarListado()
        {
            Console.WriteLine("\n--- Listado General de Pacientes ---");

            if (contadorPacientes == 0)
            {
                Console.WriteLine("No hay pacientes registrados en el sistema actualmente.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("| {0,-12} | {1,-20} | {2,-4} | {3,-18} | {4,-9} |",
                "Documento", "Nombre", "Edad", "Tipo Atención", "Prioridad"));
            Console.WriteLine("--------------------------------------------------------------------------------");

            for (int i = 0; i < contadorPacientes; i++)
            {
                Console.WriteLine(string.Format("| {0,-12} | {1,-20} | {2,-4} | {3,-18} | {4,-9} |",
                    documentos[i],
                    nombres[i],
                    edades[i],
                    tiposAtencion[i],
                    prioridades[i]));
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"Total de pacientes registrados: {contadorPacientes} / {maxPacientes}");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void BuscarPacienteDocumento()
        {
            Console.WriteLine("\n--- Búsqueda de Paciente ---");

            if (contadorPacientes == 0)
            {
                Console.WriteLine("No hay pacientes registrados en el sistema para realizar la búsqueda.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese el número de documento del paciente: ");
            string documentoBuscar = Console.ReadLine();

            bool encontrado = false;
            int indiceEncontrado = -1;

            for (int i = 0; i < contadorPacientes; i++)
            {
                if (documentos[i] == Convert.ToInt32(documentoBuscar))
                {
                    encontrado = true;
                    indiceEncontrado = i;
                    break;
                }
            }

            if (encontrado)
            {
                Console.WriteLine("\nPaciente Encontrado");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Documento:       {documentos[indiceEncontrado]}");
                Console.WriteLine($"Nombre Completo: {nombres[indiceEncontrado]}");
                Console.WriteLine($"Edad:            {edades[indiceEncontrado]} años");
                Console.WriteLine($"Tipo Atención:   {tiposAtencion[indiceEncontrado]}");
                Console.WriteLine($"Nivel Prioridad: {prioridades[indiceEncontrado]}");
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró ningún paciente con el documento '{documentoBuscar}'.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarPacienteTipoAtencion()
        {
            Console.WriteLine("\n--- Cantidad de pacientes por Tipo de Atención ---");

            if (contadorPacientes == 0)
            {
                Console.WriteLine("No hay pacientes registrados en el sistema para generar estadísticas.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            int contUrgencias = 0;
            int contConsultaGeneral = 0;
            int contPrioritaria = 0;

            for (int i = 0; i < contadorPacientes; i++)
            {
                if (tiposAtencion[i] == "Urgencias")
                {
                    contUrgencias++;
                }
                else if (tiposAtencion[i] == "Consulta General")
                {
                    contConsultaGeneral++;
                }
                else if (tiposAtencion[i] == "Prioritaria")
                {
                    contPrioritaria++;
                }
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Urgencias:          {contUrgencias} pacientes");
            Console.WriteLine($"Consulta General:   {contConsultaGeneral} pacientes");
            Console.WriteLine($"Atención Prioritaria:{contPrioritaria} pacientes");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total evaluados:    {contadorPacientes} pacientes");

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void PacienteMayorPrioridad()
        {
            Console.WriteLine("\n--- Paciente con Mayor Prioridad ---");

            if (contadorPacientes == 0)
            {
                Console.WriteLine("No hay pacientes registrados en el sistema para evaluar prioridades.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // PASO 1: Encontrar cuál es el nivel de prioridad más alto actualmente
            int prioridadMaxima = prioridades[0];
            for (int i = 1; i < contadorPacientes; i++)
            {
                if (prioridades[i] > prioridadMaxima)
                {
                    prioridadMaxima = prioridades[i];
                }
            }

            Console.WriteLine($"\nEl nivel de prioridad más alto registrado es: {prioridadMaxima}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("| {0,-12} | {1,-20} | {2,-4} | {3,-18} | {4,-9} |",
                "Documento", "Nombre", "Edad", "Tipo Atención", "Prioridad"));
            Console.WriteLine("--------------------------------------------------------------------------------");

            int cantidadMaximos = 0;
            for (int i = 0; i < contadorPacientes; i++)
            {
                if (prioridades[i] == prioridadMaxima)
                {
                    Console.WriteLine(string.Format("| {0,-12} | {1,-20} | {2,-4} | {3,-18} | {4,-9} |",
                        documentos[i],
                        nombres[i],
                        edades[i],
                        tiposAtencion[i],
                        prioridades[i]));

                    cantidadMaximos++;
                }
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"Se encontraron {cantidadMaximos} paciente(s) con la prioridad máxima.");

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
