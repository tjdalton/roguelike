#ifndef WORLD_H
#define WORLD_H
#include "tile.h"
#include <vector>
#include <list>
#include <cstdlib>
#include "log.h"
#pragma once
using namespace std;
static const int DEPTH = 20;
static const int WIDTH = 60;
static Log *log = new Log("debug.log");
class World {
	vector<vector<Tile> > grid;
	Entity *player;
	list<Entity> mobs;

public:
	Tile *getCell(int,int);
	World(void);
	Entity *getPlayer();
	void moveMob(int, int, Entity*);
	void handleInput(Entity*, char);
	Entity *getMob(Entity);
	void addMob(Entity);
	void tick(void);
	void pickUp(Entity*);
};
#endif