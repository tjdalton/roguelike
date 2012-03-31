using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roguelike
{
    class Entity
    {
        private char icon;
        private String name;
        private String uniqueId;
        private int x;
        private int y;
        private List<Item> inventory;
        private Dictionary<String, int> stats;
        private ConsoleColor colour;

        public Entity(char c)
        {
            icon = c;
            x = 1;
            y = 1;
            String tmp = generateId();
            inventory = new List<Item>();
            stats = new Dictionary<String, int>();
            //ids.push_front(tmp);
            uniqueId = tmp;
            stats.Add("STR", 25);
            stats.Add("CON", 12);
            stats.Add("DEX", 9);
            stats.Add("INT", 20);
            stats.Add("WIS", 14);
            stats.Add("CHA", 5);
        }

        public char getIcon()
        {
            return icon;
        }

        public ConsoleColor getColour()
        {
            return colour;
        }

        public void setColour(ConsoleColor c)
        {
            colour = c;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String s)
        {
            name = s;
        }

        public void setX(int i)
        {
            x = i;
        }

        public void setY(int i)
        {
            y = i;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setBlank()
        {
            icon = ' ';
        }

        public void setPos(int i, int j)
        {
            x = i;
            y = j;
        }

        public String getUniqueId()
        {
            return uniqueId;
        }

        public String generateId()
        {
            String output = "#";
            Random random = new Random();
            for (int i = 0; i <= 10; i++)
            {
                output += (char)random.Next(65, 122);
            }
            return output;
        }

        public void addItem(Item i)
        {
            inventory.Add(i);
        }

        public int getStat(String s)
        {
            return stats[s];
        }
    }
}
