#include "item.h"

char Item::getIcon(){
	return icon;
}

Item::Item(char c){
	icon = c;
}