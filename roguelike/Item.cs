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

        public char Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public ConsoleColor Colour
        {
            get { return colour; }
            set { colour = value; }
        }
    }
}
