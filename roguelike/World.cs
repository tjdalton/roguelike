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

        public Tile getCell(int i, int j)
        {
            return grid[i, j];
        }

        public Entity getPlayer()
        {
            return player;
        }

        public World()
        {
            mobs = new List<Entity>();
            msgQueue = new Queue<String>();
            // grid = new List<List<Tile>>();
            player = new Entity('@');
            player.setPos(5, 5);
            //List<Tile> tmp = new List<Tile>();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    // grid.ElementAt(i).ElementAt(j) = new Tile();

                    // tmp.Add(new Tile());
                    grid[i, j] = new Tile();
                }
                // grid.Add(tmp);
            }
        }

        public void moveMob(int i, int j, Entity e)
        {
            if (!getCell(j, i).isSolid() && !getCell(j, i).isOccupied())
            {
                getCell(e.getY(), e.getX()).removeMob();
                redraw(e);
                e.setPos(i, j);
                getCell(e.getY(), e.getX()).setMob(e);
                redraw(e);
            }
        }

        public void redraw(Entity e)
        {
            Console.SetCursorPosition(e.getX(), e.getY());
            Console.ForegroundColor = getCell(e.getY(), e.getX()).getColour();
            Console.Write(getCell(e.getY(), e.getX()).getIcon());
            Console.ResetColor();
            
        }

        public void handleInput(Entity e, String c)
        {
            switch (c)
            {
                case "1":
                case "NumPad1":
                    moveMob(e.getX() - 1, e.getY() + 1, e);
                    break;
                case "2":
                case "DownArrow":
                case "NumPad2":
                    moveMob(e.getX(), e.getY() + 1, e);
                    break;
                case "3":
                case "NumPad3":
                    moveMob(e.getX() + 1, e.getY() + 1, e);
                    break;
                case "4":
                case "LeftArrow":
                case "NumPad4":
                    moveMob(e.getX() - 1, e.getY(), e);
                    break;
                case "5":
                    break;
                case "6":
                case "RightArrow":
                case "NumPad6":
                    moveMob(e.getX() + 1, e.getY(), e);
                    break;
                case "7":
                case "NumPad7":
                    moveMob(e.getX() - 1, e.getY() - 1, e);
                    break;
                case "8":
                case "UpArrow":
                case "NumPad8":
                    moveMob(e.getX(), e.getY() - 1, e);
                    break;
                case "9":
                case "NumPad9":
                    moveMob(e.getX() + 1, e.getY() - 1, e);
                    break;
                case "OemComma":
                    pickUp(e);
                    break;
            }
        }

        public Entity getMob(Entity e)
        {
            Entity tmp = null;
            foreach (Entity m in mobs)
            {
                if (m.getUniqueId() == e.getUniqueId())
                    tmp = m;
                break;
            }

            return tmp;
        }

        public void addMob(Entity e)
        {
            mobs.Add(e);
        }

        public void tick()
        {
            Random random = new Random();
            foreach (Entity e in mobs)
            {
                handleInput(e, random.Next(1, 9).ToString());
            }
            displayStats();
        }

        public void displayStats()
        {
            Console.SetCursorPosition(66, 1);
            Console.Write(player.getStat("STR"));
            Console.SetCursorPosition(66, 2);
            Console.Write(player.getStat("DEX"));
            Console.SetCursorPosition(66, 3);
            Console.Write(player.getStat("CON"));
            Console.SetCursorPosition(66, 4);
            Console.Write(player.getStat("INT"));
            Console.SetCursorPosition(66, 5);
            Console.Write(player.getStat("WIS"));
            Console.SetCursorPosition(66, 6);
            Console.Write(player.getStat("CHA"));
        }

        public void pickUp(Entity e)
        {
            int x = e.getX();
            int y = e.getY();
            while (getCell(y, x).getContents().Count != 0)
            {
                Item tmp = getCell(y, x).getContents().Dequeue();
                player.addItem(tmp);
                addMessage("You have picked up " + tmp.getDescription());
            }
        }

        public void addMessage(String s)
        {
            msgQueue.Enqueue(s);
        }

        public void popMessage()
        {
            if (!isMsgEmpty())
                msgQueue.Dequeue();
        }

        public bool isMsgEmpty()
        {
            return msgQueue.Count == 0;
        }

        public String viewMessage()
        {
            if (!isMsgEmpty()){
                return msgQueue.Peek();
            }
            else{
                return "";
            }
        }



    }
}
