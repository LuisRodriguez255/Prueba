using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba
{
    class Program
    {
        private static double total = 0;
        private static string[] pedidos = new string[100];
        private static string[] platos = new string[10];
        private static double[] precios = new double[10];
        private static string[] tipoComidas = new string[10];

        static void Main(string[] args)
        {
            Console.WriteLine("--- Sistema de restaurante ---\n");
            MostrarMenu();
            Console.ReadKey();
        }

        private static void CerrarPrograma()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"PROGRAMA CERRADO! EL TOTAL GANADO POR PEDIDO ES DE {total}$");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\nEscoja una opción\n");
            Console.WriteLine("1. Ingresar platos \n2. Modificar Plato\n3. Eliminar plato \n4. Mostrar carta \n5. Realizar pedido");
            Console.WriteLine();

            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    AgregarPlato();
                    MostrarMenu();
                    break;

                case 2:
                    ModificarPlato();
                    MostrarMenu();
                    break;

                case 3:
                    EliminarPlato();
                    MostrarMenu();
                    break;

                case 4:
                    MostrarPlatos();
                    MostrarMenu();
                    break;

                case 5:
                    RealizarPedidos();
                    MostrarMenu();
                    break;

                case 6:
                    CerrarPrograma();
                    break;
            }
        }

        private static void RealizarPedidos()
        {
            Console.WriteLine("\nIngrese el numero de personas que desean ordenar: ");
            int i = 0;
            double totalDePedidos = 0;
            int numeroPersonas = int.Parse(Console.ReadLine());

            Console.WriteLine("\nCarta:");

            foreach (var item in platos)
            {
                Console.WriteLine($"Plato: {item}");
            }

            while (i < numeroPersonas)
            {
                Console.WriteLine("\nIngrese el nombre de plato que desea ordenar: ");
                string nombreP = Console.ReadLine();
                pedidos[i] = nombreP;
                int indice = Array.IndexOf(platos, nombreP);
                totalDePedidos += precios[indice];
                total += precios[indice];

                i++;
            }

            Console.WriteLine($"\nPEDIDOS HECHOS! Total a pagar: {totalDePedidos}");
        }

        private static void AgregarPlato()
        {
            

            for (int i = 0; i < platos.Length; i++)
            {
                Console.WriteLine($"Ingrese el nombre del plato #{i}");
                string nombrePlato = Console.ReadLine();
                platos[i] = nombrePlato;
            }

            for (int j = 0; j < precios.Length; j++)
            {
                Console.WriteLine($"Ingrese el precio del plato #{j}");
                double precio = double.Parse(Console.ReadLine());
                precios[j] = precio;
            }

            for (int x = 0; x < tipoComidas.Length; x++)
            {
                Console.WriteLine("Ingrese el tipo de plato que es (aperitivo, carne, pescado, postre)");
                string tipoComida = Console.ReadLine();
                tipoComidas[x] = tipoComida;
                continue;
            }
        }

        private static void ModificarPlato()
        {
            Console.WriteLine("\nIngrese el nombre del plato que desea ingresar:");
            string nombreAnterior = Console.ReadLine();

            foreach (var item in platos)
            {
                if (item.ToLower() == nombreAnterior.ToLower())
                {
                    int indice = Array.IndexOf(platos, nombreAnterior);
                    Console.WriteLine("Ingrese el nuevo Nombre Del plato que desea ingresar:");
                    string nombreNuevo = Console.ReadLine();
                    platos[indice] = nombreNuevo;

                    Console.WriteLine("Ingrese el nuevo Precio Del plato que desea ingresar:");
                    double precioNuevo = double.Parse(Console.ReadLine());
                    precios[indice] = precioNuevo;

                    Console.WriteLine("Ingrese el nuevo Tipo De Plato que desea ingresar:");
                    string tipoNuevo = Console.ReadLine();
                    tipoComidas[indice] = tipoNuevo;
                }
            }
        }

        private static void EliminarPlato()
        {
            Console.WriteLine("\nIngrese el nombre del plato que desea eliminar:");
            string nombre = Console.ReadLine();

            int indice = Array.IndexOf(platos, nombre);

            platos[indice] = "elemento borrado";
            precios[indice] = 0;
            platos[indice] = "elemento borrado";
        }

        private static void MostrarPlatos()
        {
            for (int i = 0; i < platos.Length; i++)
            {
                Console.WriteLine($"\nPlato #{i}: {platos[i]}");
            }

            for (int j = 0; j < precios.Length; j++)
            {
                Console.WriteLine($"\nPrecio del plato #{j}: {precios[j]}");
            }

            for (int x = 0; x < tipoComidas.Length; x++)
            {
                Console.WriteLine($"\nTipo de comida del plato #{x}: {tipoComidas[x]}");
            }
        }
    }
}