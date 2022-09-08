using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba
{
    class Program
    {
        private static double total = 0;
        private static List<string> pedidos = new List<string>();

        private static List<Plato> platos = new List<Plato> 
        {
            new Plato { NombrePlato = "Seco de pollo", Precio = 2.5, TipoComida = "carne"},
            new Plato { NombrePlato = "Pescado frito", Precio = 2.5, TipoComida = "pescado"},
            new Plato { NombrePlato = "Helado de chocolate", Precio = 1.25, TipoComida = "postre"},
            new Plato { NombrePlato = "Porción de patacones", Precio = 1, TipoComida = "aperitivo"},
            new Plato { NombrePlato = "Porción de chifles", Precio = 1, TipoComida = "aperitivo"},
            new Plato { NombrePlato = "Ceviche de pescado", Precio = 2.5, TipoComida = "pescado"},
            new Plato { NombrePlato = "Seco de carne", Precio = 1, TipoComida = "carne"},
            new Plato { NombrePlato = "Tallarin de carne", Precio = 1, TipoComida = "carne"},
            new Plato { NombrePlato = "Filete de pescado", Precio = 1, TipoComida = "pescado"},
            new Plato { NombrePlato = "Pie de maracuya", Precio = 1, TipoComida = "postre"}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("--- Sistema de restaurante ---\n");
            MostrarMenu();
            Console.ReadKey();
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\nEscoja una opción\n");
            Console.WriteLine("1. Ingresar plato \n2.Modificar Plato\n3.Eliminar plato \n4.Mostrar carta \n5.Realizar pedido \n6.Cerrar programa");
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
                    RealizarPedido();
                    MostrarMenu();
                    break;

                case 6:
                    CerrarPrograma();
                    break;
            }
        }

        private static void CerrarPrograma()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"PROGRAMA CERRADO! EL TOTAL GANADO POR PEDIDO ES DE {total}$");
            Console.ReadKey();
        }

        private static void AgregarPlato()
        {
            Console.WriteLine("Ingrese el nombre del plato");
            string nombrePlato = Console.ReadLine();
            Console.WriteLine("Ingrese el precio del plato");
            double precio = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el tipo de plato que es (aperitivo, carne, pescado, postre)");
            string tipoComida = Console.ReadLine();

            Plato plato = new Plato
            {
                NombrePlato = nombrePlato,
                Precio = precio,
                TipoComida = tipoComida
            };

            platos.Add(plato);
        }

        private static void ModificarPlato()
        {
            Console.WriteLine("\nIngrese el nombre del plato que desea ingresar:");
            string nombreAnterior = Console.ReadLine();

            foreach (var item in platos)
            {
                if (item.NombrePlato.ToLower() == nombreAnterior.ToLower())
                {
                    Console.WriteLine("Ingrese el nuevo nombre del plato que desea ingresar:");
                    string nombreNuevo = Console.ReadLine();
                    item.NombrePlato = nombreNuevo;
                }
            }
        }

        private static void EliminarPlato()
        {
            Console.WriteLine("\nIngrese el nombre del plato que desea eliminar:");
            string nombre = Console.ReadLine();

            var itm = platos.SingleOrDefault(x => x.NombrePlato.ToLower() == nombre.ToLower());

            if (itm != null)
            {
                platos.Remove(itm);

                Console.WriteLine("Plato eliminado");
            }
        }

        private static void MostrarPlatos()
        {
            foreach (var item in platos)
            {
                Console.WriteLine($"Nombre del plato: {item.NombrePlato} \nPrecio del plato: {item.Precio} \n Tipo de comida: {item.TipoComida}");
            }
        }

        private static void RealizarPedido()
        {
            Console.WriteLine("\nIngrese el numero de personas que desean ordenar: ");
            int i = 0;
            double totalDePedidos = 0;
            int numeroPersonas = int.Parse(Console.ReadLine());


            Console.WriteLine("\nCarta:");

            foreach (var item in platos)
            {
                Console.WriteLine($"Nombre del plato: {item.NombrePlato}");
            }

            while (i < numeroPersonas)
            {
                Console.WriteLine("\nIngrese el nombre de plato que desea ordenar: ");
                string nombreP = Console.ReadLine();

                pedidos.Add(nombreP);

                int index = platos.FindIndex((c) => c.NombrePlato.ToLower() == nombreP.ToLower());
                var plato = platos.ElementAt(index);
                total += plato.Precio;
                totalDePedidos += plato.Precio;

                i++;
            }

            Console.WriteLine($"PEDIDOS HECHOS! Total a pagar: {totalDePedidos}");
        }
    }

    internal class Plato
    {
        public string NombrePlato { get; set; }
        public double Precio { get; set;  }
        public string TipoComida { get; set; }
    }
}
