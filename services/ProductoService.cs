using MICRUDConsola.Models;
namespace MICRUDConsola.services
{
    public class ProductoService
    {
        List<Producto> productos = new List<Producto>();
        int contadorId = 1;
        public void CrearProducto()
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine()!;
            Console.WriteLine("Precio: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine()!);
            Console.WriteLine("Cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine()!);
            Producto nuevo = new Producto { Id = contadorId++, Nombre = nombre, Precio = precio, Cantidad=cantidad };
            productos.Add(nuevo);
            Console.WriteLine("Producto agregado. ");

        }
        public void ListarProducto()
        {
            decimal total_global = 0;
            foreach (var item in productos)
            {
                decimal total_producto = item.Cantidad * item.Precio;
                total_global += total_producto;
                Console.WriteLine($"ID: {item.Id} - Nombre: {item.Nombre} - cantidad: {item.Cantidad} - precio: {item.Precio:F2} - Total: {total_producto:F2} ");

            }
            
            Console.WriteLine($"El total de todos los productos es: {total_global:F2} ");
        }
        public void ActualizarProducto()
        {
            Console.WriteLine("Ingrese el ID para actualizar");
            int id = Convert.ToInt32(Console.ReadLine()!);
            var producto = productos.FirstOrDefault(pre => pre.Id == id);
            if (producto != null)
            {
                Console.Write("Nuevo Nombre: ");
                producto.Nombre = Console.ReadLine()!;
                Console.Write("Nuevo Precio: ");
                producto.Precio = Convert.ToDecimal(Console.ReadLine()!);
                Console.Write("Nueva cantidad: ");
                producto.Precio = Convert.ToInt32(Console.ReadLine()!);
                Console.WriteLine("Producto actualizado. \n");

            }
            else
            {
                Console.WriteLine("Producto no encontrado. \n");
            }
        }
        public void EliminarProducto()
        {
            Console.WriteLine("Ingrese ID para eliminar producto");
            int id = Convert.ToInt32(Console.ReadLine());
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado...");
            }
            else
            {
                Console.WriteLine("Producto no encotrado");
            }
        }
    
    }
}