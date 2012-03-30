#include "entity.h"
#include "game.h"
#include <time.h>
char Entity::getIcon(){
	return icon;
}
Entity::Entity(char  c){
	icon = c;
	x = 1;
	y = 1;
	string tmp = generateId();
	ids.push_front(tmp);
	uniqueId = tmp;
	colour = COLOR_WHITE;
}
string Entity::getName(){
	return name;
}
void Entity::setName(string s){
	name = s;
}

string Entity::getUniqueId(){
	return uniqueId;
}

int Entity::getX(){
	return x;
}
chtype Entity::getColour(){
	return colour;
}

void Entity::setColour(chtype c){
	colour = c;
}

int Entity::getY(){
	return y;
}

void Entity::setX(int i){
	x = i;
}
void Entity::setY(int i){
	y = i;
}

void Entity::setPos(int i, int j){
	x = i;
	y = j;
}

void Entity::setBlank(){
	icon = ' ';
}

void Entity::addItem(Item *item){
	inventory.push_front(*item);
}

string Entity::generateId(){
	string out = "#";
	int numb;
	srand (time(NULL));
	for (int i = 0; i <=10; i++){
	numb = (rand() % 122) + 49;
	out += (char)numb;
	}
	return out;
}