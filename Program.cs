using System;

namespace CarritoComprasExamen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var interfaz = new Interfaz();
            int opcion = 0;
            while(opcion != Interfaz.OPCION_SALIR)
            {
                interfaz.MostrarMenu();
                opcion = interfaz.PedirOpcionDeMenu();
                interfaz.ProcesarOpcion(opcion);
            }
        }
    }
}
