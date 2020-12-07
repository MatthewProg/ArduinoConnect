#include <SoftwareSerial.h>
#include <ESP8266WiFi.h>

#include "ArduinoConnect.hpp"

#define WIFI_SSID "SSID"
#define WIFI_PASS "Password"

void setup()
{
    Serial.begin(9600);
    Serial.println("Starting WiFi..");
    WiFi.begin(WIFI_SSID,WIFI_PASS);

    Serial.print("Establishing connection");
    while (WiFi.status() != WL_CONNECTED) {  //Wait for the WiFI connection completion
    delay(500);
    Serial.print(".");
    }
    Serial.println("\nConnected!");

    ArduinoConnect ac("http://192.168.2.193:5000/api","264EE7BD447045B7A8F075DCEEE2B23A358960780BFB41B1B0");
}

void loop()
{
    // if(WiFi.status()== WL_CONNECTED){
    // }
    // else {
    //     Serial.println("WIFI ERROR");
    // }
}