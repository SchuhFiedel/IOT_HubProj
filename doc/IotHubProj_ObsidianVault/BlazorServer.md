# Blazor Server - ASP.Net

## UI
The main interactive user interface, which displays data sent by the connected devices and can send variable changes to these devices, will be a Blazor web-app based on the Blazor Server Visual Studio Template. 

Initially there will only be a overview / home page, and one page per connected device with corresponding controls/display components.
The homepage will show the Connected Devices, their names and their power level (if available).
The navigation, as well as the list on the home page, will lead to each devices individual page in the web-app.

In a further iteration device pages could be generic, thus being defined by the device that connects to them - in which way this will be possible is not yet determined.
## REST Service
The Blazor server will act as a REST service towards the Blazor frontend, as well as towards the devices on the network. Furthermore it will connect to some kind of database

## Database
### Mongo DB Docker Container

Start Docker Container:
```docker run -dp 27017:27017 --name my-mongo -d mongo```

Connection string: 
```mongodb://localhost:27017```

[C#.Net Documentation](https://www.mongodb.com/docs/drivers/csharp/v2.19/) 

connect to mongo docker
```docker exec -it my-mongo bash```

mongo shell command
```mongosh```