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
        private Queue<String> msgQueue;

        public Tile GetCell(int i, int j)
        {
            return grid[i, j];
        }

        public Entity Player
        {
            get { return player; }
            set { player = value; }
        }

        public World()
        {
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
        }

        public void Redraw(Entity e)
        {
            Console.SetCursorPosition(e.X, e.Y);
            Console.ForegroundColor = GetCell(e.Y, e.X).Colour;
            Console.Write(GetCell(e.Y, e.X).Icon);
            Console.ResetColor();

        }

        public void HandleInput(Entity e, String c)
        {
            switch (c)
            {
                case "1":
                case "NumPad1":
                    MoveMob(e.X - 1, e.Y + 1, e);
                    break;
                case "2":
                case "DownArrow":
                case "NumPad2":
                    MoveMob(e.X, e.Y + 1, e);
                    break;
                case "3":
                case "NumPad3":
                    MoveMob(e.X + 1, e.Y + 1, e);
                    break;
                case "4":
                case "LeftArrow":
                case "NumPad4":
                    MoveMob(e.X - 1, e.Y, e);
                    break;
                case "5":
                    break;
                case "6":
                case "RightArrow":
                case "NumPad6":
                    MoveMob(e.X + 1, e.Y, e);
                    break;
                case "7":
                case "NumPad7":
                    MoveMob(e.X - 1, e.Y - 1, e);
                    break;
                case "8":
                case "UpArrow":
                case "NumPad8":
                    MoveMob(e.X, e.Y - 1, e);
                    break;
                case "9":
                case "NumPad9":
                    MoveMob(e.X + 1, e.Y - 1, e);
                    break;
                case "OemComma":
                    PickUp(e);
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
                HandleInput(e, random.Next(1, 9).ToString());
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

        public void AddMessage(String s)
        {
            msgQueue.Enqueue(s);
        }

        public void PopMessage()
        {
            if (!MsgEmpty())
                msgQueue.Dequeue();
        }

        public bool MsgEmpty()
        {
            return msgQueue.Count == 0;
        }

        public String ViewMessage()
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
