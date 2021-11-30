<h1 align="center">Arduino Connect (Web)</h1>

<p align="center">
    <a href="/./LICENSE"><img src="https://img.shields.io/github/license/VegetaTheKing/ArduinoConnect"></a>
</p>

<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about">About</a></li>
    <li>
        <a href="#getting-started">Getting Started</a>
        <ul>
            <li><a href="#project-structure">Project structure</a></li>
            <li><a href="#set-up">Set up</a></li>
        </ul>
    </li>
    <li><a href="#license">License</a></li>
  </ol>
</details>

## About

The goal of the project was to create an IoT platform for easily collecting and processing data.
It allows users to log data from devices, present it in tables designed by them and exchange signals between devices.
The project a contains web platform with UI and API as well as ready to use library for Arduino.

## Getting Started

### Project structure

`ArduinoConnect.Web` - ASP.NET Core 3.1 MVC project<br>
`ArduinoConnect.DataAccess` - .NET Standard 2.0 project<br>
`Tests/ArduinoConnect.Web.Tests` - .NET Core 3.1 NUnit tests project<br>
`Tests/ArduinoConnect.DataAccess` - .NET Core 3.1 NUnit tests project<br>
`ArduinoConnect.NodeMCU` - PlatformIO NodeMCU v3 project<br>
`ArduinoConnectAddictional` - Folder with exported MS SQL database

### Set up

##### Application projects
1. Clone repository `git clone https://github.com/VegetaTheKing/ArduinoConnect.git`
2. Open `ArduinoConnect.sln`

##### NodeMCU project
1. Clone repository `git clone https://github.com/VegetaTheKing/ArduinoConnect.git`
2. Install PlatformIO IDE from <a href="https://marketplace.visualstudio.com/items?itemName=platformio.platformio-ide">link</a>
3. Open VS Code
4. In PIO Home click Open project
5. Navigate to repo location and open `ArduinoConnect.NodeMCU`

##### MS SQL database
1. Clone repository `git clone https://github.com/VegetaTheKing/ArduinoConnect.git`
2. Open Microsoft SQL Server Management Studio
3. Login to server
4. Add new login to SQL Server named `dbuser` with password `IoT_W@rld`
5. Databases->RMB->Restore database, select device and then navigate to `ArduinoConnectAddictional/ArduinoConnect.bak`

`NOTE: You can use any other database, SQL is in ArduinoConnectAddictional, just remember to change connection string`

## [License](/./LICENSE)

```
MIT License

Copyright (c) 2021 Mateusz Ciaglo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```