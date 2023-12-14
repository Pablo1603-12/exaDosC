
using pmarnez.DAL;
using pmarnez.Servicio;

class Program
{
    static void Main()
    {
        using (var context = new ExaDosContext())
        {
            context.Database.EnsureCreated();

            var vajillaService = new VajillaService(context);
           

            while (true)
            {
                Console.WriteLine("1. Alta de Nuevo Elemento de Vajilla");
                Console.WriteLine("2. Mostrar Stock de Vajilla");
                Console.WriteLine("4. Salir");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        vajillaService.RealizarAltaNuevoElementoVajilla();
                        break;
                    case 2:
                        vajillaService.MostrarStockVajilla();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
