#ifndef ENTITY_H
#define ENTITY_H
#include <string>
#include <list>
#include "item.h"
#include <cstdlib>
#pragma once
#if defined(WIN32) || defined(_WIN32) || defined(__WIN32)
#include <curses.h>
#include <windows.h>
#else
#include <ncurses.h>
#include <unistd.h>
#endif
using namespace std;
static  list<string> ids; 
class Entity{
	char icon;
	string name;
	string uniqueId;
	int x;
	int y;
	chtype colour;
	list<Item> inventory;
public:
	char  getIcon();
	string getName();
	void setName(string);
	//void moveMob(char);
	void setX(int);
	int getX();
	int getY();
	void setY(int);
	//void moveMob(int, int);
	void setBlank();
	Entity( char );
	void setPos(int, int);
	string getUniqueId();
	string generateId();
	chtype getColour();
	void setColour(chtype);
	void addItem(Item *);
};
#endif