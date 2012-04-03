using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roguelike
{
    class Game
    {
        public static World world;
        static void Main(string[] args)
        {
            Game game = new Game();
            game.initScreen();
            game.initWorld();
            game.printWorld();
            game.populate();
            game.gameLoop();
           
        }

        public void initWorld()
        {
            world = new World();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (i == 0 || j == 0 || i == 19 || j == 59)
                    {
                        world.getCell(i, j).toggleSolid();
                    }
                }
            }
        }

        public void gameLoop()
        {
            String ch = "";
            ConsoleKeyInfo tmp = new ConsoleKeyInfo();
            while (ch != "Q" && tmp.Modifiers != ConsoleModifiers.Shift)
            {
              //  ConsoleKeyInfo tmp = Console.ReadKey();
              //  ConsoleKey tmp2 = tmp.Key;
                tmp = Console.ReadKey(true);
               // ch = Console.ReadKey(true).Key.ToString();
                ch = tmp.KeyChar.ToString();
                if(ch == "\0" || ch == ",")
                    ch = tmp.Key.ToString();
               // ch = Console.ReadKey(true).KeyChar;
                world.handleInput(world.getPlayer(), ch);
                world.tick();
                //printWorld();
                if (ch != "Q" && tmp.Modifiers != ConsoleModifiers.Shift)
                {
                    processMessage();

                }
            }
        }

        public void populate()
        {
            world.getCell(5, 5).setMob(world.getPlayer());
            world.getPlayer().setColour(ConsoleColor.Cyan);
            Entity tmp = new Entity('o');
            tmp.setColour(ConsoleColor.Green);
            tmp.setPos(10, 10);
            world.getCell(10, 10).setMob(tmp);
            world.addMob(tmp);
            world.getCell(5, 5).getMob().setPos(5, 5);
            world.getCell(9,3).addContents(new Item('='));
            world.getCell(9, 3).getContents().Peek().setColour(ConsoleColor.Magenta);
            printWorld();

        }

        public void processMessage()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for(int i= 0; i < 5; i++){
            Console.SetCursorPosition(i, 20);
            Console.Write(world.viewMessage());
            world.popMessage();
            }
            Console.ResetColor();
        }

        public void printWorld()
        {
            for(int i = 0; i < 20; i++){
                for(int j = 0; j < 60; j++){
                    Console.SetCursorPosition(j,i);
                    Console.ForegroundColor = world.getCell(i, j).getColour();
                    Console.Write(world.getCell(i, j).getIcon());
                }
            }

            Console.SetCursorPosition(61, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Str: ");
            Console.SetCursorPosition(61, 2);
            Console.Write("Dex: ");
            Console.SetCursorPosition(61, 3);
            Console.Write("Con: ");
            Console.SetCursorPosition(61, 4);
            Console.Write("Int: ");
            Console.SetCursorPosition(61, 5);
            Console.Write("Wis: ");
            Console.SetCursorPosition(61, 6);
            Console.Write("Cha: ");
            Console.ResetColor();
            world.displayStats();
        }

        public void initScreen()
        {
            Console.CursorVisible = false;
        }


        public void drawcell(int i, int j)
        {
        }

    }
}
