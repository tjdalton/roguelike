#ifndef LOG_H
#define LOG_H
#include <fstream>
#include <string.h>
#include <string>
using namespace std;

class Log {
  public:
    Log(string filename);
    ~Log();
    void Write(string logline, char severity);
  private:
    ofstream m_stream;
};

#endif