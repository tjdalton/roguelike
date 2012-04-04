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
            String tmp = GenerateId();
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

        public char Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public ConsoleColor Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }


        public void SetBlank()
        {
            icon = ' ';
        }

        public void SetPos(int i, int j)
        {
            x = i;
            y = j;
        }

        public String UniqueId
        {
            get { return uniqueId; }
        }


        public String GenerateId()
        {
            String output = "#";
            Random random = new Random();
            for (int i = 0; i <= 10; i++)
            {
                output += (char)random.Next(65, 122);
            }
            return output;
        }

        public void AddItem(Item i)
        {
            inventory.Add(i);
        }

        public int GetStat(String s)
        {
            return stats[s];
        }
    }
}
