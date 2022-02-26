using CarritoComprasExamen.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoComprasExamen
{
    internal class DatosProductos
    {
		public static Dictionary<string, Producto> Productos = new Dictionary<string, Producto>()
		{
			{"SP001", new Producto("SP001", "Candybar", 2d, 10)},
			{"SP002", new Producto("SP002", "Chocolate Browni", 3d, 20) },
			{"SP003", new Producto("SP003", "Bottle of water", 1.5d, 10) },
			{"EA001", new Producto("EA001", "Laptop", 850d, 5) },
			{"EA002", new Producto("EA002", "iPhone 5", 625d, 3) },
			{"EA003", new Producto("EA003", "Memory Stick", 12d, 8) },
			{"EA004", new Producto("EA004", "Plastic Table", 25d, 2) },
			{"WE001", new Producto("WE001", "Apple (in grams)", 0.005d, 5000) },
			{"WE002", new Producto("WE002", "Rice (in grams)", 0.003d, 3000) },
			{"WE003", new Producto("WE003", "Peanuts (in grams)", 0.007d, 5000)}
		};
    }
}
