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

        public char getIcon()
        {
            if (this.isOccupied())
                return mob.getIcon();
            else if (contents.Count != 0)
                return contents.Peek().getIcon();
            else if (this.isSolid())
                return '#';
            else
                return '.';

        }

        public Queue<Item> getContents()
        {
            return contents;
        }

        public void setMob(Entity e){
            mob = e;
            occupied = true;
        }

        public ConsoleColor getColour()
        {
            if (isOccupied())
                return mob.getColour();
            else if (contents.Count != 0)
                return contents.Peek().getColour();
            else
                return ConsoleColor.Gray;
        }

        public bool isSolid(){
            return solid;
        }

        public void toggleSolid(){
            solid = !solid;
        }

        public bool isOccupied(){
            return occupied;
        }

        public void toggleOccupied(){
            occupied = !occupied;
        }

        public void addContents(Item i){
            contents.Enqueue(i);
        }

        public Tile(){
            contents = new Queue<Item>();
            solid = false;
            occupied  = false;
        }

        public void removeMob()
        {
            mob = null;
            occupied = false;
        }

        public Entity getMob()
        {
            return mob;
        }
    }
}
