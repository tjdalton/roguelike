#include "log.h"

Log::Log(string filename) {
  m_stream.open(filename.c_str());
}

void Log::Write(string logline, char severity){
    string sevMsg = "";
    switch(severity){
        case 'E':
            sevMsg = "ERROR: ";
            break;
        case 'I':
            sevMsg = "INFO: ";
            break;
        case 'W':
            sevMsg = "WARNING: ";
            break;
    }
   // strcat(sevMsg,logline);
  m_stream << sevMsg << " " << logline << endl;
}

Log::~Log(){
  m_stream.close();
}