//#include "world.h"
#include <iostream>
#include "game.h"

WINDOW *create_newwin(int height, int width, int starty, int startx)
{	WINDOW *local_win;
	local_win = newwin(height, width, starty, startx);
	wrefresh(local_win);		
	return local_win;
}
void destroy_win(WINDOW *local_win)
{	
	wborder(local_win, ' ', ' ', ' ',' ',' ',' ',' ',' ');
	wrefresh(local_win);
	delwin(local_win);
}
WINDOW *output;
WINDOW *dungeon;
WINDOW *stats;
int main(){
	initScreen();
	start_color();
	initWorld();
	printWorld();
	populate();
	gameLoop();
	endwin();
	return 0;
}
void populate(){
	world->getCell(5,5)->setMob(world->getPlayer());
	world->getPlayer()->setColour(COLOR_BLUE);
	/*msgQueue.push("Hello World");
	msgQueue.push("Hello World1");
	msgQueue.push("Hello World2");
	msgQueue.push("Hello World3");
	msgQueue.push("Hello World4");
	msgQueue.push("Hello World5");
	msgQueue.push("Hello World6");*/
	Entity *tmp = new Entity('o');
	tmp->setColour(COLOR_GREEN);
	tmp->setPos(10,10);
	world->getCell(10,10)->setMob(tmp);
	world->addMob(*tmp);
	world->getCell(5,5)->getMob().setPos(5,5);
	world->getCell(9,3)->addContents(new Item('='));
	printWorld();
	wprintw(stats,"Line 1\n");
	wprintw(stats,"Line 2\n");
	wprintw(stats,"Line 3\n");
	wprintw(stats,"Line 4\n");
	wprintw(stats,"Line 5\n");
	wprintw(stats,"Line 6\n");
	wrefresh(stats);
	//refresh();
	//wrefresh(dungeon);
	//refresh();
}
void gameLoop(){
	char ch = 'z';
	while(ch != 'Q'){
		ch = getch();
		world->handleInput(world->getPlayer(), ch);
		world->tick();
		printWorld();
		wrefresh(dungeon);
		if (ch != 'Q'){
			processMessage();
		}
		//refresh();
	}
}
void processMessage(){
	int y = 0;
	while(!msgQueue.empty()){
		if (y == 5){
			y =0;
			//Sleep(300);
		}
		mvwprintw(output, y, 0,msgQueue.front());
		wrefresh(output);
		msgQueue.pop();
		y++;
	}
}
void initScreen(){
	initscr();
	noecho();
	raw();
	curs_set(0);
	keypad(stdscr, TRUE);
	dungeon = create_newwin(DEPTH+1, WIDTH+1, 0,0);
	output = create_newwin(5, 60, 20, 0);
	stats = create_newwin(20,20,0,60);
	refresh();
}
void printWorld(){
	for (int i = 0; i < DEPTH; i++){
		for(int j = 0; j < WIDTH; j++){
			//mvwaddch(dungeon, i,j,world->getCell(i,j)->getIcon() );
			drawCell(i,j);
		}
	}
	wrefresh(dungeon);
	//wprintw(output, "test");
	//wrefresh(output);
	//refresh();
}

void drawCell(int i, int j){

	init_pair(1, COLOR_RED, COLOR_BLACK);
	init_pair(2, COLOR_GREEN, COLOR_BLACK);
	init_pair(3, COLOR_YELLOW, COLOR_BLACK);
	init_pair(4, COLOR_BLUE,COLOR_BLACK);
	init_pair(5, COLOR_MAGENTA,COLOR_BLACK);
	init_pair(6, COLOR_CYAN,COLOR_BLACK);
	init_pair(7, COLOR_WHITE, COLOR_BLACK);
	init_pair(99, COLOR_WHITE, COLOR_BLACK);
	chtype c = world->getCell(i, j)->getColour();
	if (c == 99){
		wattron(dungeon, COLOR_PAIR(99) | A_BOLD);
		mvwaddch(dungeon, i, j, world->getCell(i,j)->getIcon());
		wattroff(dungeon, COLOR_PAIR(99) | A_BOLD);
	}
	else{
	//wattron(dungeon, COLOR_PAIR(c));
	//wattron(dungeon, 0x23EF);
	wattron(dungeon, COLOR_PAIR(c));
	mvwaddch(dungeon, i, j, world->getCell(i,j)->getIcon());
	wattroff(dungeon, COLOR_PAIR(c));
	}
	
	//wattroff(dungeon, COLOR_PAIR(1));
	
	//wattrset(dungeon, A_NORMAL);
}

void initWorld(){
	world = new World();
	for (int i = 0; i < DEPTH; i++){
		for(int j = 0; j < WIDTH; j++){
			if (i == 0 || j == 0 || i == DEPTH - 1 || j == WIDTH -1){
				world->getCell(i,j)->setWall(true);
			}
		}
	}
}
