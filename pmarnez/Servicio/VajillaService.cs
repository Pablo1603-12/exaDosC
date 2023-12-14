using pmarnez.DAL;

namespace pmarnez.Servicio;
    public class VajillaService
    {
        private readonly ExaDosContext _context;

        public VajillaService(ExaDosContext context)
        {
            _context = context;
        }

        public void RealizarAltaNuevoElementoVajilla()
        {
            Console.WriteLine("Ingrese el nombre del elemento de vajilla:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la descripción del elemento de vajilla:");
            string descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad del elemento de vajilla:");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            AltaNuevoElementoVajilla(nombre, descripcion, cantidad);

            Console.WriteLine("Nuevo elemento de vajilla agregado con éxito.");
        }

        private void AltaNuevoElementoVajilla(string nombre, string descripcion, int cantidad)
        {
            string codigo = "Elem-" + nombre;

            Vajilla nuevoElementoVajilla = new Vajilla
            {
                CodigoElemento = codigo,
                NombreElemento = nombre,
                DescripcionElemento = descripcion,
                CantidadElemento = cantidad
            };

            _context.Vajillas.Add(nuevoElementoVajilla);
            _context.SaveChanges();
        }

        public void MostrarStockVajilla()
        {
            var vajillas = _context.Vajillas.ToList();

            foreach (var vajilla in vajillas)
            {
                Console.WriteLine($"Código: {vajilla.CodigoElemento}, Nombre: {vajilla.NombreElemento}, Cantidad: {vajilla.CantidadElemento}");
            }
        }
    }


