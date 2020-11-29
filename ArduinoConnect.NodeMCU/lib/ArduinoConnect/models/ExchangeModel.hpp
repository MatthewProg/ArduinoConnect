#ifndef __EXCHANGEMODEL_HPP_INCLUDED__
#define __EXCHANGEMODEL_HPP_INCLUDED__

#include <Arduino.h>
#include <ArduinoJson.h>

struct ExchangeModel
{
    int ID;
    int OwnerID;
    String AddTime;
    int ReceiverID;
    String Command;
    String ReceiverDevice;
};

#endif