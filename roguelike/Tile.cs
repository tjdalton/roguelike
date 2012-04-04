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
        public enum TileType { Floor = 46, Wall = 35, OpenDoor = 47, ClosedDoor = 43 };
        private TileType type;


        public char Icon
        {
            get
            {
                if (this.Occupied)
                    return mob.Icon;
                else if (contents.Count != 0)
                    return contents.Peek().Icon;
                else
                    return (char)type;
            }
        }

        public TileType Type
        {
            set { type = value; }
            get { return type; }
        }

        public String Description
        {
            get
            {
                String output = "";
                if (this.Occupied && this.Mob.Icon != '@'){
                    output = String.Concat(output,"You see: ", this.Mob.Description, " ");
                }
                if (contents.Count != 0)
                {
                    if (output == "")
                        output = "You see: ";
                    output = String.Concat(output, contents.Peek().Description, " ");
                }
                if (output.Length == 0)
                    output = "You see nothing on the floor";
                return output;
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
            get
            {
                if (type == TileType.Floor || type == TileType.OpenDoor)
                    return false;
                else
                    return true;
            }
        }
        public bool Occupied
        {
            get 
            {
                if (mob == null)
                    return false;
                else
                    return true;
            }
        }

        public void AddContents(Item i)
        {
            contents.Enqueue(i);
        }

        public Tile()
        {
            contents = new Queue<Item>();
            type = TileType.Floor;
        }

        public void RemoveMob()
        {
            mob = null;
        }

    }
}
