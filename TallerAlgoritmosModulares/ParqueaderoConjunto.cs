using System;

namespace TallerAlgoritmosModulares
{
    internal class ParqueaderoConjunto
    {
        private int maxIngresos = 40;
        private int contadorIngresos = 0;

        private string[] placas = new string[40];
        private string[] torres = new string[40];
        private string[] apartamentos = new string[40];
        private int[] horasIngreso = new int[40];
        private string[] horasIngresoStr = new string[40];
        private int[] horasSalida = new int[40];
        private string[] horasSalidaStr = new string[40];
        private string[] tiposVehiculo = new string[40];

        public void Ejecutar()
        {
            int seleccion = 0;

            while (seleccion != 5)
            {
                Console.WriteLine("\n---------------- Control de Parqueadero (Visitantes) ----------------");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Registrar ingreso de vehículo");
                Console.WriteLine("2. Consultar salida de vehículo (Calcular permanencia)");
                Console.WriteLine("3. Mostrar cantidad de ingresos por tipo");
                Console.WriteLine("4. Identificar vehículo con mayor permanencia");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Opción: ");

                seleccion = Convert.ToInt32(Console.ReadLine());

                while (seleccion < 1 || seleccion > 5)
                {
                    Console.WriteLine("Seleccione una opción correcta (1-5):");
                    seleccion = Convert.ToInt32(Console.ReadLine());
                }

                switch (seleccion)
                {
                    case 1:
                        RegistrarIngreso();
                        break;
                    case 2:
                        ConsultarSalida();
                        break;
                    case 3:
                        MostrarIngresosPorTipo();
                        break;
                    case 4:
                        MostrarMayorPermanencia();
                        break;
                    case 5:
                        Console.WriteLine("Regresando al menú principal...");
                        break;
                }
            }
        }

        private void RegistrarIngreso()
        {
            Console.WriteLine("\n--- Registrar Ingreso de Vehículo ---");

            if (contadorIngresos >= maxIngresos)
            {
                Console.WriteLine("Error: Se ha alcanzado el límite máximo de 40 ingresos diarios.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese la placa del vehículo: ");
            string placaIngresada = Console.ReadLine().ToUpper().Trim();

            if (BuscarVehiculoDentro(placaIngresada) != -1)
            {
                Console.WriteLine($"Error: El vehículo con placa '{placaIngresada}' ya se encuentra dentro del parqueadero.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            placas[contadorIngresos] = placaIngresada;

            Console.Write("Torre visitada: ");
            torres[contadorIngresos] = Console.ReadLine();

            Console.Write("Apartamento visitado: ");
            apartamentos[contadorIngresos] = Console.ReadLine();

            int minutosTotales;
            string formatoTexto;
            CapturarHora("Hora de ingreso", out minutosTotales, out formatoTexto);

            horasIngreso[contadorIngresos] = minutosTotales;
            horasIngresoStr[contadorIngresos] = formatoTexto;

            tiposVehiculo[contadorIngresos] = SeleccionarTipoVehiculo();

            horasSalida[contadorIngresos] = -1;
            horasSalidaStr[contadorIngresos] = "--:--";

            Console.WriteLine($"\nVehículo {placaIngresada} registrado correctamente a las {formatoTexto}.");
            contadorIngresos++;

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void ConsultarSalida()
        {
            Console.WriteLine("\n--- Consultar Salida de Vehículo ---");

            if (contadorIngresos == 0)
            {
                Console.WriteLine("No se han registrado ingresos el día de hoy.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese la placa del vehículo que se retira: ");
            string placaBuscar = Console.ReadLine().ToUpper().Trim();

            int indice = BuscarVehiculoDentro(placaBuscar);

            if (indice == -1)
            {
                Console.WriteLine($"Error: No se encontró ningún vehículo dentro con la placa '{placaBuscar}'.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            int minutosSalida;
            string formatoSalidaStr;
            CapturarHora("Hora de salida", out minutosSalida, out formatoSalidaStr);

            if (minutosSalida < horasIngreso[indice])
            {
                Console.WriteLine("Error: La hora de salida no puede ser menor a la hora de ingreso registrada.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            horasSalida[indice] = minutosSalida;
            horasSalidaStr[indice] = formatoSalidaStr;

            int minutosPermanencia = minutosSalida - horasIngreso[indice];
            string tiempoTexto = ConvertirMinutosATexto(minutosPermanencia);

            Console.WriteLine($"\nSalida registrada para la placa {placaBuscar}.");
            Console.WriteLine($"Tiempo total de permanencia: {tiempoTexto}");

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarIngresosPorTipo()
        {
            Console.WriteLine("\n--- Cantidad de Ingresos por Tipo de Vehículo ---");

            if (contadorIngresos == 0)
            {
                Console.WriteLine("No hay registros de ingresos para contabilizar.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            int conteoCarros = 0;
            int conteoMotos = 0;
            int conteoBicicletas = 0;

            for (int i = 0; i < contadorIngresos; i++)
            {
                if (tiposVehiculo[i] == "Carro")
                {
                    conteoCarros++;
                }
                else if (tiposVehiculo[i] == "Moto")
                {
                    conteoMotos++;
                }
                else if (tiposVehiculo[i] == "Bicicleta")
                {
                    conteoBicicletas++;
                }
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Carros:     {conteoCarros}");
            Console.WriteLine($"Motos:      {conteoMotos}");
            Console.WriteLine($"Bicicletas: {conteoBicicletas}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total de ingresos registrados: {contadorIngresos}");

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private void MostrarMayorPermanencia()
        {
            Console.WriteLine("\n--- Vehículo con Mayor Permanencia ---");

            if (contadorIngresos == 0)
            {
                Console.WriteLine("No hay registros en el sistema para evaluar permanencias.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            int maxPermanencia = -1;
            int indiceMayor = -1;

            for (int i = 0; i < contadorIngresos; i++)
            {
                if (horasSalida[i] != -1)
                {
                    int permanenciaActual = horasSalida[i] - horasIngreso[i];
                    if (permanenciaActual > maxPermanencia)
                    {
                        maxPermanencia = permanenciaActual;
                        indiceMayor = i;
                    }
                }
            }

            if (indiceMayor == -1)
            {
                Console.WriteLine("Información: Todos los vehículos registrados siguen dentro del parqueadero.");
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine($"Placa:            {placas[indiceMayor]}");
                Console.WriteLine($"Tipo de Vehículo: {tiposVehiculo[indiceMayor]}");
                Console.WriteLine($"Torre / Apto:     Torre {torres[indiceMayor]} - Apto {apartamentos[indiceMayor]}");
                Console.WriteLine($"Hora Ingreso:     {horasIngresoStr[indiceMayor]}");
                Console.WriteLine($"Hora Salida:      {horasSalidaStr[indiceMayor]}");
                Console.WriteLine($"Permanencia:      {ConvertirMinutosATexto(maxPermanencia)}");
                Console.WriteLine("------------------------------------------------------------");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // MÉTODOS AUXILIARES Y VALIDACIONES
        private int BuscarVehiculoDentro(string placa)
        {
            for (int i = 0; i < contadorIngresos; i++)
            {
                if (placas[i] == placa && horasSalida[i] == -1)
                {
                    return i;
                }
            }
            return -1;
        }

        private string SeleccionarTipoVehiculo()
        {
            int opcion = 0;
            while (opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Seleccione el tipo de vehículo:");
                Console.WriteLine("1. Carro");
                Console.WriteLine("2. Moto");
                Console.WriteLine("3. Bicicleta");
                Console.Write("Opción (1-3): ");
                opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion < 1 || opcion > 3)
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }

            if (opcion == 1) return "Carro";
            if (opcion == 2) return "Moto";
            return "Bicicleta";
        }

        private void CapturarHora(string contexto, out int minutosTotales, out string formatoTexto)
        {
            int hora = -1;
            int minuto = -1;

            Console.WriteLine($"{contexto}");
            while (hora < 0 || hora > 23)
            {
                Console.Write("  Ingrese la hora (0-23): ");
                hora = Convert.ToInt32(Console.ReadLine());
                if (hora < 0 || hora > 23) Console.WriteLine("  Error: Hora fuera de rango (0 a 23).");
            }

            while (minuto < 0 || minuto > 59)
            {
                Console.Write("  Ingrese los minutos (0-59): ");
                minuto = Convert.ToInt32(Console.ReadLine());
                if (minuto < 0 || minuto > 59) Console.WriteLine("  Error: Minutos fuera de rango (0 a 59).");
            }

            minutosTotales = (hora * 60) + minuto;
            formatoTexto = string.Format("{0:00}:{1:00}", hora, minuto);
        }

        private string ConvertirMinutosATexto(int minutos)
        {
            int horas = minutos / 60;
            int minsRestantes = minutos % 60;
            return string.Format("{0}h {1:00}m", horas, minsRestantes);
        }
    }
}