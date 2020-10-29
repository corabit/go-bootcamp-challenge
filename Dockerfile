FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
# Copy csproj and restore
COPY src/go-bootcamp-challenge.csproj ./src/
COPY test/go-bootcamp-challenge-test.csproj ./test/


RUN dotnet restore ./src/go-bootcamp-challenge.csproj
RUN dotnet restore ./test/go-bootcamp-challenge-test.csproj

COPY . . 
RUN dotnet build ./src/go-bootcamp-challenge.csproj
RUN dotnet build ./test/go-bootcamp-challenge-test.csproj

RUN dotnet test ./test/go-bootcamp-challenge-test.csproj

RUN dotnet publish ./src/go-bootcamp-challenge.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "go-bootcamp-challenge.dll"]