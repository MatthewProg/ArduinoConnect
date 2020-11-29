#include "ArduinoConnect.hpp"

ArduinoConnect::ArduinoConnect(String apiUrl, String token)
{
    _apiUrl = apiUrl;
    _token = token;
}

ArduinoConnect::~ArduinoConnect()
{
}

bool ArduinoConnect::SendExchange(int ReceiverID, String Command, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "SendExchange()");
    HTTPClient http;
    http.begin(_apiUrl + "/exchange/Post?token=" + _token);
    
    http.addHeader("Content-Type", "application/json");

    u16 buff_size = sizeof(ReceiverID) + sizeof(Command) + sizeof(ReceiverDevice) + 34;

    DynamicJsonDocument data(buff_size);
    data["ReceiverID"] = ReceiverID;
    data["Command"] = Command;
    data["ReceiverDevice"] = ReceiverDevice;

    String payload;
    serializeJson(data,payload);

    #if defined(DEBUG_AC_DATA) || defined(DEBUG_AC_DATA_PRETTY)
        Serial.println(payload);
    #endif

    int code = http.POST(payload);
    DEBUG_INFO("Response code: ",code);
    http.end();
    DEBUG_INFO("END", "");
    if(code==200)
        return true;
    else
        return false;
}

bool ArduinoConnect::GetNewestExchange(ExchangeModel *out, int ReceiverID, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "GetNewestExchange()");
    HTTPClient http;

    String url = _apiUrl + "/exchange/GetNewestExchange?token=" + _token;
    if(ReceiverID != -1) url += "&ReceiverID=" + String(ReceiverID);
    if(ReceiverDevice != "") url += "&ReceiverDevice=" + UrlConverter::Encode(ReceiverDevice);

    http.begin(url);
    int code = http.GET();
    DEBUG_INFO("Response code: ",code);
    if(code==200)
    {
        DEBUG_INFO("Response size: ",http.getSize());
        DynamicJsonDocument doc(JSON_OBJECT_SIZE(6) + http.getSize());

        #ifdef DEBUG_AC_INFO
        auto err = deserializeJson(doc,http.getStream());
        #else
        deserializeJson(doc,http.getStream());
        #endif
        
        DEBUG_INFO("Doc mem usg: ",doc.memoryUsage());
        DEBUG_INFO("Error code: ", err.c_str());

        DEBUG_DATA(doc);

        http.end();
        out->ID = doc["id"];
        out->OwnerID = doc["ownerID"];
        out->AddTime = doc["addTime"].as<String>();
        out->ReceiverID = doc["receiverID"];
        out->ReceiverDevice = doc["receiverDevice"].as<String>();
        out->Command = doc["command"].as<String>();
        DEBUG_INFO("END", "");
        return true;
    }
    else
    {
        http.end();
        DEBUG_INFO("END", "");
        return false;
    }
}

JsonObject ArduinoConnect::GetNewestExchange(JsonObject filter, int ReceiverID, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "GetNewestExchange()");
    HTTPClient http;

    String url = _apiUrl + "/exchange/GetNewestExchange?token=" + _token;
    if(ReceiverID != -1) url += "&ReceiverID=" + String(ReceiverID);
    if(ReceiverDevice != "") url += "&ReceiverDevice=" + UrlConverter::Encode(ReceiverDevice);

    http.begin(url);
    int code = http.GET();
    DEBUG_INFO("Response code: ",code);
    if(code==200)
    {
        DEBUG_INFO("Response size: ",http.getSize());
        DynamicJsonDocument doc(JSON_OBJECT_SIZE(6) + http.getSize() + filter.memoryUsage());

        #ifdef DEBUG_AC_INFO
        auto err = deserializeJson(doc,http.getStream(),DeserializationOption::Filter(filter));
        #else
        deserializeJson(doc,http.getStream(),DeserializationOption::Filter(filter));
        #endif

        DEBUG_INFO("Doc mem usg: ",doc.memoryUsage());
        DEBUG_INFO("Error code: ", err.c_str());

        DEBUG_DATA(doc);

        http.end();
        DEBUG_INFO("END", "");
        return doc.as<JsonObject>();
    }
    else
    {
        http.end();
        StaticJsonDocument<1> empty;
        DEBUG_INFO("END", "");
        return empty.as<JsonObject>();
    }
}

bool ArduinoConnect::GetOldestExchange(ExchangeModel *out, int ReceiverID, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "GetOldestExchange()");
    HTTPClient http;

    String url = _apiUrl + "/exchange/GetOldestExchange?token=" + _token;
    if(ReceiverID != -1) url += "&ReceiverID=" + String(ReceiverID);
    if(ReceiverDevice != "") url += "&ReceiverDevice=" + UrlConverter::Encode(ReceiverDevice);

    http.begin(url);
    int code = http.GET();
    DEBUG_INFO("Response code: ",code);
    if(code==200)
    {
        DEBUG_INFO("Response size: ",http.getSize());

        DynamicJsonDocument doc(JSON_OBJECT_SIZE(6) + http.getSize());

        #ifdef DEBUG_AC_INFO
        auto err = deserializeJson(doc,http.getStream());
        #else
        deserializeJson(doc,http.getStream());
        #endif

        DEBUG_INFO("Doc mem usg: ",doc.memoryUsage());
        DEBUG_INFO("Error code: ", err.c_str());

        DEBUG_DATA(doc);

        http.end();
        out->ID = doc["id"];
        out->OwnerID = doc["ownerID"];
        out->AddTime = doc["addTime"].as<String>();
        out->ReceiverID = doc["receiverID"];
        out->ReceiverDevice = doc["receiverDevice"].as<String>();
        out->Command = doc["command"].as<String>();
        DEBUG_INFO("END", "");
        return true;
    }
    else
    {
        http.end();
        DEBUG_INFO("END", "");
        return false;
    }
}

JsonObject ArduinoConnect::GetOldestExchange(JsonObject filter, int ReceiverID, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "GetOldestExchange()");
    HTTPClient http;

    String url = _apiUrl + "/exchange/GetOldestExchange?token=" + _token;
    if(ReceiverID != -1) url += "&ReceiverID=" + String(ReceiverID);
    if(ReceiverDevice != "") url += "&ReceiverDevice=" + UrlConverter::Encode(ReceiverDevice);

    http.begin(url);
    int code = http.GET();
    DEBUG_INFO("Response code: ",code);
    if(code==200)
    {
        DEBUG_INFO("Response size: ",http.getSize());

        DynamicJsonDocument doc(JSON_OBJECT_SIZE(6) + http.getSize() + filter.memoryUsage());

        #ifdef DEBUG_AC_INFO
        auto err = deserializeJson(doc,http.getStream(),DeserializationOption::Filter(filter));
        #else
        deserializeJson(doc,http.getStream(),DeserializationOption::Filter(filter));
        #endif

        DEBUG_INFO("Doc mem usg: ",doc.memoryUsage());
        DEBUG_INFO("Error code: ", err.c_str());

        DEBUG_DATA(doc);

        http.end();
        DEBUG_INFO("END", "");
        return doc.as<JsonObject>();
    }
    else
    {
        http.end();
        StaticJsonDocument<1> empty;
        DEBUG_INFO("END", "");
        return empty.as<JsonObject>();
    }
}

JsonArray ArduinoConnect::GetAllExchange(JsonArray filter, int ReceiverID, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "GetAllExchange()");
    HTTPClient http;

    String url = _apiUrl + "/exchange/GetAllExchange?token=" + _token;
    if(ReceiverID != -1) url += "&ReceiverID=" + String(ReceiverID);
    if(ReceiverDevice != "") url += "&ReceiverDevice=" + UrlConverter::Encode(ReceiverDevice);

    http.begin(url);
    int code = http.GET();
    DEBUG_INFO("Response code: ",code);
    if(code==200)
    {
        int elements = http.getSize() / JSON_OBJECT_SIZE(6);
        DEBUG_INFO("Response size: ",http.getSize());

        DynamicJsonDocument doc(JSON_ARRAY_SIZE(elements) + elements*JSON_OBJECT_SIZE(6) + http.getSize() + filter.memoryUsage());

        #ifdef DEBUG_AC_INFO
        auto err = deserializeJson(doc,http.getStream(),DeserializationOption::Filter(filter));
        #else
        deserializeJson(doc,http.getStream(),DeserializationOption::Filter(filter));
        #endif

        DEBUG_INFO("Doc mem usg: ",doc.memoryUsage());
        DEBUG_INFO("Error code: ", err.c_str());

        DEBUG_DATA(doc);

        http.end();
        DEBUG_INFO("END", "");
        return doc.as<JsonArray>();
    }
    else
    {
        http.end();
        StaticJsonDocument<1> empty;
        DEBUG_INFO("END", "");
        return empty.as<JsonArray>();
    }
}

int ArduinoConnect::GetNoOfExchange(int ReceiverID, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "GetNoOfExchange()");
    HTTPClient http;

    String url = _apiUrl + "/exchange/GetNoOfExchange?token=" + _token;
    if(ReceiverID != -1) url += "&ReceiverID=" + String(ReceiverID);
    if(ReceiverDevice != "") url += "&ReceiverDevice=" + UrlConverter::Encode(ReceiverDevice);

    http.begin(url);
    int code = http.GET();
    DEBUG_INFO("Response code: ",code);
    if(code==200)
    {
        String out = http.getString();
        
        #if defined(DEBUG_AC_DATA) || defined(DEBUG_AC_DATA_PRETTY)
        Serial.println(out);
        #endif

        http.end();
        DEBUG_INFO("END", "");
        return out.toInt();
    }
    else
    {
        http.end();
        DEBUG_INFO("END", "");
        return -1;
    }
}

bool ArduinoConnect::DeleteExchange(int ReceiverID, String ReceiverDevice)
{
    DEBUG_INFO("BEGIN ", "DeleteExchange()");
    HTTPClient http;

    String url = _apiUrl + "/exchange/Delete?token=" + _token;
    if(ReceiverID != -1) url += "&ReceiverID=" + String(ReceiverID);
    if(ReceiverDevice != "") url += "&ReceiverDevice=" + UrlConverter::Encode(ReceiverDevice);

    http.begin(url);
    int code = http.GET();
    http.end();
    DEBUG_INFO("Response code: ",code);
    if(code==200)
    {
        #if defined(DEBUG_AC_DATA) || defined(DEBUG_AC_DATA_PRETTY)
        Serial.println(true);
        #endif

        DEBUG_INFO("END", "");
        return true;
    }
    else
    {
        #if defined(DEBUG_AC_DATA) || defined(DEBUG_AC_DATA_PRETTY)
        Serial.println(false);
        #endif

        DEBUG_INFO("END", "");
        return false;
    }
}