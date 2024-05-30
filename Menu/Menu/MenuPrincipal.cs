using System;
using System.Collections.Generic;

namespace Menu
{
    class MenuPrincipal
    {
        public List<Menu> menu = new List<Menu>();
        int numeroMenu = 0;


        public MenuPrincipal(Dictionary<string, string[]> menus)
        {
            int fila = 1;
            int col = 1;
            // Recorro el diccionario
            //int pos = 1;
            foreach (var subMenu in menus)
            {
                menu.Add(new Menu(0, subMenu.Key, subMenu.Value, fila, col));
                col += subMenu.Key.Length + 2;
            }

        }



        public void dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;

            foreach (var c in menu)
            {
                Console.SetCursorPosition(c.columna, c.fila++);
                if (c == menu[numeroMenu])
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(c.nombreMenu);
                    for (int i = 0; i < c.items.Length; i++)
                    {
                        Console.SetCursorPosition(c.columna, c.fila++);
                        if (c.items[i] == c.items[c.posItem])
                        {
                            Console.BackgroundColor = ConsoleColor.Red; // Cambia el color de fondo a verde
                            Console.ForegroundColor = ConsoleColor.Black; // Cambia el color del texto a negro
                            Console.WriteLine(c.items[i]);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(c.items[i]);
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(c.nombreMenu);
                    Console.SetCursorPosition(0, c.items.Length + 1);
                }
                c.fila = 1;
            }
        }
        public void arriba()
        {

            menu[numeroMenu].posItem--;

            if (menu[numeroMenu].posItem < 0)
                menu[numeroMenu].posItem = menu[numeroMenu].items.Length - 1;
            dibujar();
        }

        public void abajo()
        {

            menu[numeroMenu].posItem++;

            if (menu[numeroMenu].posItem >= menu[numeroMenu].items.Length)
                menu[numeroMenu].posItem = 0;
            dibujar();
        }

        public void izq()
        {
            numeroMenu--;

            if (numeroMenu < 0)
                numeroMenu = menu.Count - 1;
            dibujar();
        }

        public void der()
        {
            numeroMenu++;

            if (numeroMenu >= menu.Count)
                numeroMenu = 0;
            dibujar();
        }
    }
}
