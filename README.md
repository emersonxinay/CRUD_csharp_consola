# CRUD de Productos en Consola (C#)

## Descripción
Aplicación de consola en C# que permite crear, listar, actualizar y eliminar productos.  
Incluye el cálculo de total por producto y el total global acumulado.

Este proyecto está pensado como un ejemplo educativo de programación estructurada y modular en C#.

## Características
- Crear un nuevo producto.
- Listar todos los productos con su total y el total global.
- Actualizar nombre, cantidad y precio de un producto.
- Eliminar un producto por su ID.
- Cálculo automático de totales.

## Requisitos
- .NET SDK 8 o superior
- Editor recomendado: Visual Studio Code o Visual Studio

## Instalación y ejecución

### Clonar el repositorio
```bash
git clone https://github.com/emersonxinay
```

### Entrar al directorio del proyecto
```bash
cd CRUDConsola
```

### Compilar el proyecto
```bash
dotnet build
```

### Ejecutar el proyecto
```bash
dotnet run
```

## Uso
1. Al iniciar, el programa mostrará un menú con las opciones disponibles.
2. Ingrese el número correspondiente a la acción que desea realizar.
3. Siga las instrucciones en consola para ingresar datos de productos.
4. Al listar, se mostrará el total por producto y el total global acumulado.

## Estructura del proyecto
- `Program.cs`: Punto de entrada de la aplicación.
- `Producto.cs`: Clase que define las propiedades de un producto.
- `MetodosCRUD.cs`: Métodos para crear, listar, actualizar y eliminar productos.
- `Menu.cs`: Lógica de presentación del menú en consola.

## Ejemplo sin clases ni metodos:
```cs
// Program.cs

        // Lista de productos representados como diccionarios
        List<Dictionary<string, object>> productos = new List<Dictionary<string, object>>();
        int contadorId = 1;

        while (true)
        {
            Console.WriteLine("===== CRUD de Productos (sin clases ni métodos) =====");
            Console.WriteLine("1. Crear producto");
            Console.WriteLine("2. Listar productos");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine()!;
            Console.WriteLine();

            if (opcion == "1")
            {
                Console.Write("Nombre del producto: ");
                string nombre = Console.ReadLine()!;

                Console.Write("Precio del producto: ");
                decimal precio = Convert.ToDecimal(Console.ReadLine()!);

                var producto = new Dictionary<string, object>();
                producto["Id"] = contadorId++;
                producto["Nombre"] = nombre;
                producto["Precio"] = precio;

                productos.Add(producto);

                Console.WriteLine("Producto agregado.\n");
            }
            else if (opcion == "2")
            {
                if (productos.Count == 0)
                {
                    Console.WriteLine("No hay productos.\n");
                    continue;
                }

                Console.WriteLine("Lista de productos:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"ID: {producto["Id"]} - {producto["Nombre"]} - ${((decimal)producto["Precio"]):F2}");
                }
                Console.WriteLine();
            }
            else if (opcion == "3")
            {
                Console.Write("Ingrese el ID del producto a actualizar: ");
                int idActualizar = Convert.ToInt32(Console.ReadLine());

                bool encontrado = false;
                foreach (var producto in productos)
                {
                    if ((int)producto["Id"] == idActualizar)
                    {
                        Console.Write("Nuevo nombre: ");
                        producto["Nombre"] = Console.ReadLine()!;

                        Console.Write("Nuevo precio: ");
                        producto["Precio"] = Convert.ToDecimal(Console.ReadLine()!);

                        Console.WriteLine("Producto actualizado.\n");
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Producto no encontrado.\n");
                }
            }
            else if (opcion == "4")
            {
                Console.Write("Ingrese el ID del producto a eliminar: ");
                int idEliminar = Convert.ToInt32(Console.ReadLine());

                int index = -1;
                for (int i = 0; i < productos.Count; i++)
                {
                    if ((int)productos[i]["Id"] == idEliminar)
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    productos.RemoveAt(index);
                    Console.WriteLine("Producto eliminado.\n");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.\n");
                }
            }
            else if (opcion == "5")
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida.\n");
            }
        }
 
```


## Ejemplo de codigo monolito con clase y metodos:
```cs
//Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDConsola
{
    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
    class Program
    {
        List<Producto> productos = new List<Producto>();
        int contadorId = 1;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.MostrarMenu();
        }

        void MostrarMenu()
        {
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
                        CrearProducto();
                        break;
                    case "2":
                        Console.WriteLine("Listar Productos");
                        ListarProducto();
                        break;
                    case "3":
                        Console.WriteLine("Actualizar Productos");
                        ActualizarProducto();
                        break;
                    case "4":
                        Console.WriteLine("Eliminar Productos");
                        EliminarProducto();
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
        void CrearProducto()
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine()!;
            Console.WriteLine("Precio: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine()!);

            Producto nuevo = new Producto { Id = contadorId++, Nombre = nombre, Precio = precio };
            productos.Add(nuevo);
            Console.WriteLine("Producto agregado. ");

        }
        void ListarProducto()
        {
            foreach (var item in productos)
            {
                Console.WriteLine($"ID: {item.Id} - {item.Nombre} - {item.Precio:F2}");

            }
            Console.WriteLine();
        }
        void ActualizarProducto()
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
                Console.WriteLine("Producto actualizado. \n");

            }
            else
            {
                Console.WriteLine("Producto no encontrado. \n");
            }
        }
        void EliminarProducto()
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
```

## código modularizado 
```cs 
// models/Producto.cs
namespace MICRUDConsola.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
```

```cs
// services/ProductoService.cs
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
```

```cs 
//Program.cs
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
```
