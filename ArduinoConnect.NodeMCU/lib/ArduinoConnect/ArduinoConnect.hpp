#ifndef __ARDUINOCONNECT_HPP_INCLUDED__
#define __ARDUINOCONNECT_HPP_INCLUDED__

#define DEBUG_AC_INFO
#define DEBUG_AC_DATA

#include <Arduino.h>
#include <ArduinoJson.h>
#include <ESP8266HTTPClient.h>

#include "models/ExchangeModel.hpp"
#include "utilities/Converters.hpp"
#include "utilities/Defines.hpp"

class ArduinoConnect
{
private:
    String _apiUrl;
    String _token;
public:
    ArduinoConnect(String apiUrl, String token);
    ~ArduinoConnect();

    bool SendExchange(int ReceiverID, String Command, String ReceiverDevice);
    bool GetNewestExchange(ExchangeModel *out, int ReceiverID = -1, String ReceiverDevice = "");
    JsonObject GetNewestExchange(JsonObject filter, int ReceiverID = -1, String ReceiverDevice = "");
    bool GetOldestExchange(ExchangeModel *out, int ReceiverID = -1, String ReceiverDevice = "");
    JsonObject GetOldestExchange(JsonObject filter, int ReceiverID = -1, String ReceiverDevice = "");
    JsonArray GetAllExchange(JsonArray filter, int ReceiverID = -1, String ReceiverDevice = "");
    int GetNoOfExchange(int ReceiverID = -1, String ReceiverDevice = "");
    bool DeleteExchange(int ReceiverID = -1, String ReceiverDevice = "");
};

#endif