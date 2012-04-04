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
            game.InitWorld();
            game.PrintWorld();
            game.Populate();
            game.GameLoop();

        }

        public void InitWorld()
        {
            world = new World(this);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (i == 0 || j == 0 || i == 19 || j == 59)
                    {
                        world.GetCell(i, j).Type = Tile.TileType.Wall;
                    }
                }
            }
        }

        public void GameLoop()
        {
            String ch = "";
            ConsoleKeyInfo tmp = new ConsoleKeyInfo();
            while (ch != "Q" && tmp.Modifiers != ConsoleModifiers.Shift)
            {
                tmp = Console.ReadKey(true);
                world.HandleInput(world.Player, tmp);
                world.Tick();
                if (ch != "Q" && tmp.Modifiers != ConsoleModifiers.Shift)
                {
                    ProcessMessage();

                }
            }
        }

        public void Populate()
        {
            world.GetCell(5, 5).Mob = world.Player;
            world.Player.Colour = ConsoleColor.Cyan;
            Entity tmp = new Entity('o');
            tmp.Colour = ConsoleColor.Green;
            tmp.Name = "Orc";
            tmp.SetPos(10, 10);
            world.GetCell(10, 10).Mob = tmp;
            world.AddMob(tmp);
            world.GetCell(5, 5).Mob.SetPos(5, 5);
            world.GetCell(9, 3).AddContents(new Item('='));
            world.GetCell(9, 3).Contents.Peek().Colour = ConsoleColor.Magenta;
            PrintWorld();

        }

        public void ProcessMessage()
        {
            ClearConsole(20, 24, 0, 80);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(0, 20 + i);
                Console.Write(World.ViewMessage());
                World.PopMessage();
            }
            Console.ResetColor();
        }
        public void ClearConsole(int startX, int endX, int startY, int endY)
        {
            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }
        }
        public void PrintWorld()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = world.GetCell(i, j).Colour;
                    Console.Write(world.GetCell(i, j).Icon);
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
            world.DisplayStats();
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
