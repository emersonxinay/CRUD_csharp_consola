using MICRUDConsola.services;
namespace CRUDConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductoService servicio = new ProductoService();
       
     
            while (true)
            {
                Console.WriteLine("===== CRUD de Productos====");
                Console.WriteLine("1. Crear producto");
                Console.WriteLine("2. Listar producto");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine()!;
                Console.WriteLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Crear Productos");
                        servicio.CrearProducto();
                        break;
                    case "2":
                        Console.WriteLine("Listar Productos");
                        servicio.ListarProducto();
                        break;
                    case "3":
                        Console.WriteLine("Actualizar Productos");
                        servicio.ActualizarProducto();
                        break;
                    case "4":
                        Console.WriteLine("Eliminar Productos");
                        servicio.EliminarProducto();
                        break;
                    case "5":
                        Console.WriteLine("Saliendo ...");
                        return;
                    default:
                        Console.WriteLine("Opción invalida");
                        break;
                }

            }
        }
       
    }
    
}
