#ifndef LOG_H
#define LOG_H
#include <fstream>
#include <string>
using namespace std;

class Log {
  public:
    Log(char* filename);
    ~Log();
    void Write(char* logline);
  private:
    ofstream m_stream;
};

#endif