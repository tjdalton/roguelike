using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roguelike
{
    class Tile
    {
        private Entity mob;
        Queue<Item> contents;
        private bool solid;
        private bool occupied;

        public char Icon
        {
            get
            {
                if (this.Occupied)
                    return mob.Icon;
                else if (contents.Count != 0)
                    return contents.Peek().Icon;
                else if (this.Solid)
                    return '#';
                else
                    return '.';
            }
        }

        public Queue<Item> Contents
        {
            get { return contents; }
        }

        public Entity Mob
        {
            set
            {
                mob = value;
                occupied = true;
            }

            get { return mob; }
        }

        public ConsoleColor Colour
        {
            get
            {
                if (this.Occupied)
                    return mob.Colour;
                else if (contents.Count != 0)
                    return contents.Peek().Colour;
                else
                    return ConsoleColor.Gray;
            }
        }

        public bool Solid
        {
            get { return solid; }
        }
        public void ToggleSolid()
        {
            solid = !solid;
        }
        public bool Occupied
        {
            get { return occupied; }
        }

        public void ToggleOccupied()
        {
            occupied = !occupied;
        }

        public void AddContents(Item i)
        {
            contents.Enqueue(i);
        }

        public Tile()
        {
            contents = new Queue<Item>();
            solid = false;
            occupied = false;
        }

        public void RemoveMob()
        {
            mob = null;
            occupied = false;
        }

    }
}
