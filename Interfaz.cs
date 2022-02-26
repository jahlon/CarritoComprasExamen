using CarritoComprasExamen.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoComprasExamen
{
    internal class Interfaz
    {
        private const int OPCION_VER_PRODUCTOS = 1;
        private const int OPCION_AGREGAR_ITEM = 2;
        private const int OPCION_VER_CARRITO = 3;
        private const int OPCION_ELIMINAR_ITEM = 4;
        public const int OPCION_SALIR = 5;

        private const string TITULO = "CARRITO DE COMPRAS";
        private const string VER_PRODUCTOS = "VER PRODUCTOS";
        private const string AGREGAR_ITEM = "AGREGAR PRODUCTO A CARRITO";
        private const string ELIMINAR_ITEM = "ELIMINAR ITEM DE CARRITO";
        private const string VER_CARRITO = "VER CARRITO";

        private readonly Carrito _carrito;

        public Interfaz()
        {
            _carrito = new Carrito();
        }

        public void MostrarMenu()
        {
            Console.WriteLine($"=== MENU DEL {TITULO} ===");
            Console.WriteLine("\nEstas son las opciones disponibles:");
            Console.WriteLine($"{OPCION_VER_PRODUCTOS}. {VER_PRODUCTOS}");
            Console.WriteLine($"{OPCION_AGREGAR_ITEM}. {AGREGAR_ITEM}");
            Console.WriteLine($"{OPCION_VER_CARRITO}. {VER_CARRITO}");
            Console.WriteLine($"{OPCION_ELIMINAR_ITEM}. {ELIMINAR_ITEM}");
            Console.WriteLine($"{OPCION_SALIR}. SALIR");
        }

        public int PedirOpcionDeMenu()
        {
            Console.Write("\nSeleccione una opción: ");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || !(1 <= opcion && opcion <= 5))
            {
                Console.WriteLine(">> ERROR: La opción ingresada no es válida. Debe ingresar un número de 1 a 5.");
            }
            return opcion;
        }

        public void ProcesarOpcion(int opcion)
        {
            Console.WriteLine();
            switch(opcion)
            {
                case OPCION_VER_PRODUCTOS:
                    MostrarProductos(DatosProductos.Productos.Values.ToList());
                    break;
                case OPCION_AGREGAR_ITEM:
                    Console.WriteLine($"== {AGREGAR_ITEM} ==");
                    ProcesarOpcionAgregarItem();
                    break;
                case OPCION_VER_CARRITO:
                    Console.WriteLine($"== {VER_CARRITO} ==");
                    Console.WriteLine(_carrito);
                    break;
                case OPCION_ELIMINAR_ITEM:
                    Console.WriteLine($"== {ELIMINAR_ITEM} ==");
                    ProcesarEliminarItem();
                    break;
                case OPCION_SALIR:
                    ProcesarSalir();
                    break;
            }
            Console.WriteLine();
        }

        public void ProcesarOpcionAgregarItem()
        {
            Console.Write("Ingrese el código del producto: ");
            string sku = Console.ReadLine().ToUpper();
            Producto producto = DatosProductos.Productos[sku];
            if (sku.StartsWith("WE"))
                Console.Write("Ingrese la cantidad (en libras): ");
            else
                Console.Write("Ingrese la cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            try
            {
                _carrito.AgregarItem(producto, cantidad);
                Console.WriteLine(">> INFO: Se agregó el producto al carrito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">> ERROR: {ex.Message}");
            }
        }

        public void ProcesarEliminarItem()
        {
            Console.Write("Ingrese el número del item: ");
            int numero = int.Parse(Console.ReadLine());
            _carrito.EliminarItem(numero);
            Console.WriteLine(">> INFO: El item fue eliminado.");
        }

        public void ProcesarSalir()
        {
            Console.WriteLine(">> INFO: Fin del programa.");
        }

        public void MostrarProductos(List<Producto> productos)
        {
            Console.WriteLine($"{"SKU",-5}\t{"NOMBRE", -20}\t{"PRECIO", 10}\t{"UNIDADES DISPONIBLES", -20}");
            Console.WriteLine($"{"_____",-5}\t{"____________________",-20}\t{"__________",10}\t{"____________________",-20}");
            foreach (Producto producto in productos)
            {
                Console.WriteLine(producto);
            }
        }
    }
}
