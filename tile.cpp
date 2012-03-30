#include "tile.h"
#include <iostream>
char  Tile::getIcon(){
	char  tmpIcon;
	if (this->isOccupied())
		tmpIcon = mob->getIcon();
	else if (contents.size() != 0)
		tmpIcon = this->contents.front().getIcon();
	else if (isWall())
		tmpIcon = '#';
	else 
		tmpIcon = '.';
	return tmpIcon;
}

void Tile::setOccupied(bool b){
	occupied = b;
}

bool Tile::isOccupied(){
	return occupied;
}

chtype Tile::getColour(){
	if(this->isOccupied())
		return mob->getColour();
	else if (contents.size() != 0)
		return 7;
	else if (isWall())
		return 99;
	else
		return 7;
}
Entity Tile::getMob(){
	return *mob;
}
Tile::Tile(){
	wall = false;
	occupied = false;
	//contents = new queue<Item>;
}
void Tile::addContents(Item *i){
	this->contents.push(*i);
}

void Tile::setMob(Entity *e){
	mob = e;
	occupied = true;
}
queue<Item>* Tile::getContents(){
	return &contents;
}

void Tile::removeMob(){
	mob = NULL;
	occupied = false;
}

bool Tile::isWall(){
	return wall;
}
void Tile::setWall(bool b){
	wall = b;
}