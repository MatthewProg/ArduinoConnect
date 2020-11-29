#ifndef __DEFINES_HPP_INCLUDED__
#define __DEFINES_HPP_INCLUDED__

#ifdef DEBUG_AC_INFO
    #define DEBUG_INFO(n,v) {Serial.print(n);Serial.println(v);}
#else
    #define DEBUG_INFO(n,v)
#endif

#if defined(DEBUG_AC_DATA)
    #define DEBUG_DATA(v) {serializeJson(v,Serial);Serial.print("\n");}
#elif defined(DEBUG_AC_DATA_PRETTY)
    #define DEBUG_DATA(v) {serializeJsonPretty(v,Serial);Serial.print("\n");}
#else
    #define DEBUG_DATA(v)
#endif

#endif