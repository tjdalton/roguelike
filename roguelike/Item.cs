using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roguelike
{
    class Item
    {
        private char icon;
        private String description;
        private ConsoleColor colour;

        public Item(char c)
        {
            icon = c;
            description = "a murky red liquid";
        }

        public char getIcon()
        {
            return icon;
        }

        public String getDescription()
        {
            return description;
        }

        public void setColour(ConsoleColor c)
        {
            colour = c;
        }

        public ConsoleColor getColour()
        {
            return colour;
        }
    }
}
