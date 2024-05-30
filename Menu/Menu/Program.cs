using System;
using System.Collections.Generic;

namespace Menu
{
    class Item
    {
        string opcion;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal menu;

            string[] menu1 = { "Nuevo Cliente", "Modificar Cliente", "Listar Clientes", "Salir" };
            string[] menu2 = { "Nuevo Producto", "Modificar Producto", "Eliminar Producto", "Listar Producto", "Salir." };

            var menus = new Dictionary<string, string[]>
            {
                { "Archivo", menu1 }, { "Editar", menu2 },
            };

            Console.Clear();
            menu = new MenuPrincipal(menus);

            ConsoleKeyInfo tecla; // Variable para almacenar la tecla presionada

            // Bucle principal del programa que se ejecuta hasta que se presiona la tecla Enter
            menu.dibujar(); // Dibuja el menú en la posición especificada
            do
            {
                tecla = Console.ReadKey(); // Lee la tecla presionada por el usuario




                // Dependiendo de la tecla presionada, se moverá hacia arriba o abajo en el menú
                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        menu.arriba();
                        break;
                    case ConsoleKey.DownArrow:
                        menu.abajo();
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        menu.izq();
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        menu.der();
                        break;
                }
            } while (tecla.Key != ConsoleKey.Enter); // Sale del bucle cuando Enter

            Console.ReadKey();

        }
    }
}