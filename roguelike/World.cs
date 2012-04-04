using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roguelike
{
    class World
    {
        private Tile[,] grid = new Tile[20, 60];
        private Entity player;
        private List<Entity> mobs;
        private static Queue<String> msgQueue;
        private Game game;

        public Tile GetCell(int i, int j)
        {
            return grid[i, j];
        }

        public Entity Player
        {
            get { return player; }
            set { player = value; }
        }

        public World(Game g)
        {
            game = g;
            mobs = new List<Entity>();
            msgQueue = new Queue<String>();
            player = new Entity('@');
            player.SetPos(5, 5);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    grid[i, j] = new Tile();
                }
            }
        }

        public void MoveMob(int i, int j, Entity e)
        {
            if (!GetCell(j, i).Solid && !GetCell(j, i).Occupied)
            {
                GetCell(e.Y, e.X).RemoveMob();
                Redraw(e);
                e.SetPos(i, j);
                GetCell(e.Y, e.X).Mob = e;
                Redraw(e);
            }

            else if (!GetCell(j, i).Solid && GetCell(j, i).Occupied)
            {
                e.Fight(GetCell(j, i).Mob);
                if (GetCell(j, i).Mob.Dead)
                {
                    AddMessage("You slay the " + GetCell(j, i).Mob.Name);
                    mobs.Remove(GetCell(j, i).Mob);
                    GetCell(j, i).RemoveMob();
                    MoveMob(i, j, e);                 
                }
            }
        }

        public void Redraw(Entity e)
        {
            Console.SetCursorPosition(e.X, e.Y);
            Console.ForegroundColor = GetCell(e.Y, e.X).Colour;
            Console.Write(GetCell(e.Y, e.X).Icon);
            Console.ResetColor();

        }

        public void HandleInput(Entity e, ConsoleKeyInfo c)
        {
            switch (c.Key)
            {
                case ConsoleKey.NumPad1:
                    MoveMob(e.X - 1, e.Y + 1, e);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.NumPad2:
                    MoveMob(e.X, e.Y + 1, e);
                    break;
                case ConsoleKey.NumPad3:
                    MoveMob(e.X + 1, e.Y + 1, e);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad4:
                    MoveMob(e.X - 1, e.Y, e);
                    break;
                case ConsoleKey.NumPad5:
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad6:
                    MoveMob(e.X + 1, e.Y, e);
                    break;
                case ConsoleKey.NumPad7:
                    MoveMob(e.X - 1, e.Y - 1, e);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.NumPad8:
                    MoveMob(e.X, e.Y - 1, e);
                    break;
                case ConsoleKey.NumPad9:
                    MoveMob(e.X + 1, e.Y - 1, e);
                    break;
                case ConsoleKey.OemComma:
                    PickUp(e);
                    break;
                case ConsoleKey.L:
                    if (c.Modifiers != ConsoleModifiers.Shift)
                    {
                        AddMessage(GetCell(player.Y, player.X).Description);
                    }
                    break;
            }
        }
        public void HandleInput(Entity e, int c)
        {
            ConsoleKeyInfo tmp;
            switch (c)
            {
                case 1:
                    tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad1,false,false,false);
                    HandleInput(e, tmp);
                    break;
                case 2:
                    tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad2,false,false,false);
                    HandleInput(e, tmp);
                    break;
                case 3:
                    tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad3,false,false,false);
                    HandleInput(e, tmp);
                    break;
                case 4:
                    tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad4,false,false,false);
                    HandleInput(e, tmp);
                    break;
                case 5:
                    break;
                case 6:
                    tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad6,false,false,false);
                    HandleInput(e, tmp);
                    break;
                case 7:
                    tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad7,false,false,false);
                    HandleInput(e, tmp);
                    break;
                case 8:
                   tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad8,false,false,false);
                    HandleInput(e, tmp);
                    break;
                case 9:
                    tmp = new ConsoleKeyInfo('\0',ConsoleKey.NumPad9,false,false,false);
                    HandleInput(e, tmp);
                    break;
            }
        }
        public Entity GetMob(Entity e)
        {
            Entity tmp = null;
            foreach (Entity m in mobs)
            {
                if (m.UniqueId == e.UniqueId)
                    tmp = m;
                break;
            }

            return tmp;
        }

        public void AddMob(Entity e)
        {
            mobs.Add(e);
        }

        public void Tick()
        {
            Random random = new Random();
            foreach (Entity e in mobs)
            {
                HandleInput(e, random.Next(1, 9));
            }
            DisplayStats();
        }

        public void DisplayStats()
        {
            Console.SetCursorPosition(66, 1);
            Console.Write(player.GetStat("STR"));
            Console.SetCursorPosition(66, 2);
            Console.Write(player.GetStat("DEX"));
            Console.SetCursorPosition(66, 3);
            Console.Write(player.GetStat("CON"));
            Console.SetCursorPosition(66, 4);
            Console.Write(player.GetStat("INT"));
            Console.SetCursorPosition(66, 5);
            Console.Write(player.GetStat("WIS"));
            Console.SetCursorPosition(66, 6);
            Console.Write(player.GetStat("CHA"));
        }

        public void PickUp(Entity e)
        {
            int x = e.X;
            int y = e.Y;
            while (GetCell(y, x).Contents.Count != 0)
            {
                Item tmp = GetCell(y, x).Contents.Dequeue();
                player.AddItem(tmp);
                AddMessage("You have picked up " + tmp.Description);
            }
        }

        static public void AddMessage(String s)
        {
            msgQueue.Enqueue(s);
        }

        static public void PopMessage()
        {
            if (!MsgEmpty())
                msgQueue.Dequeue();
        }

        static public bool MsgEmpty()
        {
            return msgQueue.Count == 0;
        }

        static public String ViewMessage()
        {
            if (!MsgEmpty())
            {
                return msgQueue.Peek();
            }
            else
            {
                return "";
            }
        }

    }
}
