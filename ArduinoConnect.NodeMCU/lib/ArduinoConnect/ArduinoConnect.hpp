#ifndef __ARDUINOCONNECT_HPP_INCLUDED__
#define __ARDUINOCONNECT_HPP_INCLUDED__

#define DEBUG_AC_INFO
#define DEBUG_AC_DATA

#include <Arduino.h>
#include <ArduinoJson.h>
#include <ESP8266HTTPClient.h>

#include "models/ExchangeModel.hpp"
#include "models/DataTableModel.hpp"
#include "models/TokenModel.hpp"
#include "utilities/Converters.hpp"
#include "utilities/Defines.hpp"

class ArduinoConnect
{
private:
    String _apiUrl;
    String _token;
    WiFiClient _wifiClient;
public:
    ArduinoConnect(String apiUrl, String token);
    ~ArduinoConnect();

    // EXCHANGE
    bool SendExchange(int ReceiverID, String Command, String ReceiverDevice);
    bool GetNewestExchange(ExchangeModel *out, int ReceiverID = -1, String ReceiverDevice = "");
    JsonObject GetNewestExchange(JsonObject filter, int ReceiverID = -1, String ReceiverDevice = "");
    bool GetOldestExchange(ExchangeModel *out, int ReceiverID = -1, String ReceiverDevice = "");
    JsonObject GetOldestExchange(JsonObject filter, int ReceiverID = -1, String ReceiverDevice = "");
    JsonArray GetAllExchange(JsonArray filter, int ReceiverID = -1, String ReceiverDevice = "");
    int GetNoOfExchange(int ReceiverID = -1, String ReceiverDevice = "");
    bool DeleteExchange(int ReceiverID = -1, String ReceiverDevice = "");

    // DATATABLE
    JsonArray GetTables(JsonArray filter, int tableId = -1);
    JsonArray GetTablesOffset(JsonArray filter, int tableId = -1, int offset = 0, int fetch = 10);
    int GetNoOfData(int tableId = -1);
    bool AddData(DataTableModel data);
    bool DeleteData(int tableId = -1, int id = -1);

    // TOKENS
    TokenModel GenerateNewToken();
    bool DeleteToken(String token);

    // RECEIVERS
    JsonArray GetReceivers(int receiverId = -1, String description = "");
};

#endif