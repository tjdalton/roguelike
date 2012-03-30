#ifndef TILE_H
#define TILE_H
#include "entity.h"
#include <queue>
#include "item.h"
#include <curses.h>
#pragma once
using namespace std;
class Tile {
	Entity* mob;
	queue<Item> contents;
	bool wall;
	bool occupied;
public:
	char  getIcon();
	Entity getMob();
	queue<Item>* getContents();
	void setMob(Entity *);
	void removeMob();
	bool isWall();
	void setWall(bool);
	void setOccupied(bool);
	bool isOccupied();
	Tile(void);
	void addContents(Item *);
	chtype getColour();
};
#endif