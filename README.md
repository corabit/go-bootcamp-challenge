## About
***
The current project is part of the Golang Bootcamp application

This project was made in C# and .NET Core versions:

- Net Core: 3.1
- C#: 8

And use the https://sampleapis.com/css-color-names to retrieve the data.

## Run
***
You can run this project in two ways Docker and Dotnet CLI

### Docker

The project was tested with the **19.03.13** version of docker.

``````
make docker-run
``````

*Navigate to: http://localhost:8080*

### Dotnet

You need the **dotnet cli >= 3.1**

#### Run Project

This command restore and run the project:
``````
make run
``````
If you want to run without make:

``````
dotnet restore
dotnet run --project ./src/go-bootcamp-challenge.csproj
``````

*Navigate to: http://localhost:500*

#### Run test

To run the tests:
``````
make test
``````
If you want to run without make:

``````
dotnet restore
dotnet test
``````

## Testing the API
***
The project have a **Swagger Doc**, so you test the API directly there.

If you prefer Or with curl:

``````
curl {host}/api/hello-wolrd
``````
``````
curl {host}/api/colors
``````
``````
curl {host}/api/colors/15b01a
``````
The host could be http://localhost:8080 if you run with Docker or http://localhost:5000 if you run with dotnet cli

*If use VS Code you can use the REST Client extension with the Client.http file to test the API*