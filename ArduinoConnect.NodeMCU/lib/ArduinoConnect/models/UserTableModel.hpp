#ifndef __USERTABLEMODEL_HPP_INCLUDED__
#define __USERTABLEMODEL_HPP_INCLUDED__

#include <Arduino.h>

struct UserTableModel
{
    int TableID;
    int OwnerID;
    String TableName;
    String TableDescription;
    String TableSchema;
};

#endif