#ifndef __CONVERTERS_HPP_INCLUDED__
#define __CONVERTERS_HPP_INCLUDED__

#include <Arduino.h>

class UrlConverter
{
private:
    static char hex_digit(char c) { return "01234567890ABCDEF"[c & 0x0F]; }

public:
    static String Encode(String source)
    {
        char _specials[] = "$&+,/:;=?@ <>#%{}|~[]`";
        String output = "";
        for(uint i=0;i<source.length();i++)
        {
            char c = source[i];
            if(strchr(_specials,c))
            {
                output += '%';
                output += hex_digit(c>>4);
                c = hex_digit(c);
            }
            output += c;
        }
        return output;
    }
};

#endif