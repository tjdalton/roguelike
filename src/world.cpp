#include "world.h"
#if defined(WIN32) || defined(_WIN32) || defined(__WIN32)
#include <curses.h>
#else
#include <ncurses.h>
#endif
#include <time.h>
Tile  *World::getCell(int j, int i){
	return  &grid.at(i).at(j);
}

Entity * World::getPlayer(){
	return player;
}

void World::moveMob(int i, int j, Entity *mob){
	if (!this->getCell(j, i)->isOccupied() && !this->getCell(j,i)->isWall()){
		this->getCell(mob->getY(), mob->getX())->removeMob();
		mob->setPos(i, j);
		this->getCell(mob->getY(), mob->getX())->setMob(mob);
	}
}

void World::addMob(Entity e){
	mobs.push_back(e);
}

void World::tick(){
	list<Entity>::iterator it;
	for (it = mobs.begin(); it != mobs.end(); it++ ){
		int numb;
		srand (time(NULL));
		numb = (rand() % 8) + 1;
		char c[] = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
		this->handleInput(&*it, c[numb - 1]);
	}
}
Entity *World::getMob(Entity e){
	list<Entity>::iterator it;
	Entity *tmpEnty = new Entity('.');
	for (it = mobs.begin(); it != mobs.end(); it++ ){
		if (it->getUniqueId() == e.getUniqueId()){
			*tmpEnty = *it;
			continue;
		}
	}
	return tmpEnty;
}
void World::handleInput(Entity *mob, char c){
	switch((unsigned int)c){
		case '1':
			this->moveMob(mob->getX() - 1, mob->getY() + 1, mob);
			break;
		case '2':
		case 2:
		case KEY_DOWN:
			this->moveMob(mob->getX(), mob->getY()+1, mob);
			break;
		case '3':
			this->moveMob(mob->getX()+1, mob->getY()+1, mob);
			break;
		case '4':
		case 4:
		case KEY_LEFT:
			this->moveMob(mob->getX()-1, mob->getY(), mob);
			break;
		case '5':
			break;
		case '6':
		case 5:
		case KEY_RIGHT:
			this->moveMob(mob->getX()+1, mob->getY(), mob);
			break;
		case '7':
			this->moveMob(mob->getX()-1, mob->getY()-1, mob);
			break;
		case '8':
		case 3:
		case KEY_UP:
			this->moveMob(mob->getX(), mob->getY()-1, mob);
			break;
		case '9':
			this->moveMob(mob->getX()+1, mob->getY()-1, mob);
			break;
		case ',':
			log->Write("character , selected", 'I');
			this->pickUp(mob);
			break;
	}
}

void World::pickUp(Entity *mob){
	int x = mob->getX();
	int y = mob->getY();
	while(!this->getCell(y,x)->getContents()->empty()){
		Item tmp = this->getCell(y,x)->getContents()->front();
		player->addItem(&tmp);
		this->getCell(y,x)->getContents()->pop();
		
	}
}
World::World(){
	grid.resize(WIDTH, vector<Tile> (DEPTH));
	player = new Entity('@');
	this->player->setPos(5,5);
}
