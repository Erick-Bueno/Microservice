# Microservice

# Technologies Used
* C#
* Asp.Net core
* Entity Framework Core
* RabbitMQ
* Mysql

## Installation

Make sure you have the .NET Framework installed. For supported versions, visit the .NET website. [Dotnet](https://dotnet.microsoft.com/download).

1. Clone repository:

   ```bash
   git clone https://github.com/Erick-Bueno/Microservice 
    ```
2. Navigate to the project directory
 
   ```bash
   cd project
3. Run Project
   ```bash
   dotnet run
## Endpoints
### Create Order:
```c#
 {
   id: "1",
   externalId: "d02a070c-5459-4cff-83cb-f8a4e78fe5c4"
   date: 
   totalOrderValue: "1200"
 }
```
* When creating an order, the responsible microservice will communicate with the payment microservice that will process it, after which the payment microservice will communicate with the delivery microservice
* 
## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)

