using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAlgoritmosModulares
{
    internal class TurnosIPS
    {
        string[] pacientes = new string[0];
        int maxPacientes = 30;


        public void Ejecutar()
        {
            Console.WriteLine("---------------- Sistema de control de turnos para una IPS ----------------");
            Console.WriteLine("Seleccione:");
            Console.WriteLine("1. Registrar pacientes\n" +
                "2. Mostrar listado general\n" +
                "3. Buscar pacientes por documento\n" +
                "4. Mostrar cuántos pacientes hay por tipo de atención\n" +
                "5. Identificar el paciente con mayor prioridad" +
                "6. Salir");

            int seleccion = Convert.ToInt32(Console.ReadLine());

            while (seleccion < 1 || seleccion > 6)
            {
                Console.WriteLine("Seleccione una opción correcta:");
                seleccion = Convert.ToInt32(Console.ReadLine());
            }

            if (seleccion != 6)
            {
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
                    default:
                        break;
                }
            }
        }
    }
}
