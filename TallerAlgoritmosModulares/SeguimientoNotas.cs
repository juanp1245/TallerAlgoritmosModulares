using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAlgoritmosModulares
{
    internal class SeguimientoNotas
    {
        public void Ejecutar()
        {
            Console.WriteLine("Ejecutando el sistema de Notas...");

            /*
             * using System;

                class program
                {
                    const int max = 25;

                    static string[] codigo = new string[max];
                    static string[] nombre = new string[max];

                    static double[,] notas = new double[max, 3];

                    static double[] asistencia = new double[max];
                    static double[] definitiva = new double[max];

                    static string[] estado = new string[max];

                    static int cantidad = 0;

                    static void Main(string[] args)
                    {
                        int opcion;

                        do
                        {
                            Console.Clear();

                            Console.WriteLine("sistema de notas pascual bravo");
                            Console.WriteLine("1 registrar estudiantes");
                            Console.WriteLine("2 mostrar estudiantes");
                            Console.WriteLine("3 promedio general");
                            Console.WriteLine("4 mejor promedio");
                            Console.WriteLine("5 peor promedio");
                            Console.WriteLine("0 salir");

                            Console.Write("seleccione un numero: ");
                            opcion = Convert.ToInt32(Console.ReadLine());

                            switch (opcion)
                            {
                                case 1:
                                    registrar();
                                    break;

                                case 2:
                                    mostrar();
                                    break;

                                case 3:
                                    promedio();
                                    break;

                                case 4:
                                    mejor();
                                    break;

                                case 5:
                                    peor();
                                    break;

                                case 0:
                                    Console.WriteLine("fin");
                                    break;

                                default:
                                    Console.WriteLine("opcion mala");
                                    break;
                            }

                            Console.WriteLine("enter para seguir");
                            Console.ReadKey();

                        } while (opcion != 0);
                    }

                    static void registrar()
                    {
                        int n;

                        Console.Write("cuantos estudiantes va meter: ");
                        n = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            if (cantidad >= max)
                            {
                                Console.WriteLine("ya no caben mas");
                                break;
                            }

                            Console.WriteLine("estudiante " + (cantidad + 1));

                            Console.Write("codigo: ");
                            codigo[cantidad] = Console.ReadLine();

                            Console.Write("nombre: ");
                            nombre[cantidad] = Console.ReadLine();

                            for (int j = 0; j < 3; j++)
                            {
                                do
                                {
                                    Console.Write("nota " + (j + 1) + ": ");
                                    notas[cantidad, j] = Convert.ToDouble(Console.ReadLine());

                                    if (notas[cantidad, j] < 0 || notas[cantidad, j] > 5)
                                    {
                                        Console.WriteLine("la nota tiene que ser de 0 a 5");
                                    }

                                } while (notas[cantidad, j] < 0 || notas[cantidad, j] > 5);
                            }

                            Console.Write("asistencia: ");
                            asistencia[cantidad] = Convert.ToDouble(Console.ReadLine());

                            definitiva[cantidad] =
                            (notas[cantidad, 0] * 0.3) +
                            (notas[cantidad, 1] * 0.3) +
                            (notas[cantidad, 2] * 0.4);

                            if (definitiva[cantidad] >= 3.5)
                            {
                                estado[cantidad] = "aprobado";
                            }
                            else
                            {
                                if (definitiva[cantidad] >= 2)
                                {
                                    estado[cantidad] = "habilita";
                                }
                                else
                                {
                                    estado[cantidad] = "reprueba";
                                }
                            }

                            cantidad++;
                        }
                    }

                    static void mostrar()
                    {
                        if (cantidad == 0)
                        {
                            Console.WriteLine("no hay estudiantes");
                            return;
                        }

                        for (int i = 0; i < cantidad; i++)
                        {
                            Console.WriteLine("----------------");

                            Console.WriteLine("codigo: " + codigo[i]);
                            Console.WriteLine("nombre: " + nombre[i]);

                            Console.WriteLine("nota 1: " + notas[i, 0]);
                            Console.WriteLine("nota 2: " + notas[i, 1]);
                            Console.WriteLine("nota 3: " + notas[i, 2]);

                            Console.WriteLine("asistencia: " + asistencia[i]);

                            Console.WriteLine("definitiva: " + definitiva[i]);

                            Console.WriteLine("estado: " + estado[i]);
                        }
                    }

                    static void promedio()
                    {
                        double suma = 0;
                        double prom;

                        if (cantidad == 0)
                        {
                            Console.WriteLine("no hay estudiantes");
                            return;
                        }

                        for (int i = 0; i < cantidad; i++)
                        {
                            suma = suma + definitiva[i];
                        }

                        prom = suma / cantidad;

                        Console.WriteLine("promedio general: " + prom);
                    }

                    static void mejor()
                    {
                        double mayor;
                        int pos = 0;

                        if (cantidad == 0)
                        {
                            Console.WriteLine("no hay estudiantes");
                            return;
                        }

                        mayor = definitiva[0];

                        for (int i = 1; i < cantidad; i++)
                        {
                            if (definitiva[i] > mayor)
                            {
                                mayor = definitiva[i];
                                pos = i;
                            }
                        }

                        Console.WriteLine("mejor promedio");
                        Console.WriteLine("nombre: " + nombre[pos]);
                        Console.WriteLine("nota: " + mayor);
                    }

                    static void peor()
                    {
                        double menor;
                        int pos = 0;

                        if (cantidad == 0)
                        {
                            Console.WriteLine("no hay estudiantes");
                            return;
                        }

                        menor = definitiva[0];

                        for (int i = 1; i < cantidad; i++)
                        {
                            if (definitiva[i] < menor)
                            {
                                menor = definitiva[i];
                                pos = i;
                            }
                        }

                        Console.WriteLine("peor promedio");
                        Console.WriteLine("nombre: " + nombre[pos]);
                        Console.WriteLine("nota: " + menor);
                    }
                }
            */
        }
    }
}
