#ifndef GAME_H
#define GAME_H
#include "world.h"
#if defined(WIN32) || defined(_WIN32) || defined(__WIN32)
#include <curses.h>
#include <windows.h>
#else
#include <ncurses.h>
#include <unistd.h>
#endif
#include <string>
static World *world;
void initWorld(void);
void printWorld(void);
void initScreen(void);
void gameLoop(void);
void populate(void);
WINDOW *create_newwin(int height, int width, int starty, int startx);
void destroy_win(WINDOW *local_win);
static queue<const char *> msgQueue;
void processMessage();
void drawCell(int, int);
#endif