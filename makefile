docker-build:  
		docker build -t go-bootcamp-challenge .

docker-run:	
		docker run -d -p 8080:80 --name go-bootcamp-challenge go-bootcamp-challenge

docker-start:
		docker container start go-bootcamp-challenge

docker-stop:
		docker container stop go-bootcamp-challenge

docker-rm-container:
		docker container rm -f go-bootcamp-challenge

docker-rm-image:
		docker image rm go-bootcamp-challenge

build: 	restore
		dotnet build

run: 	restore
		dotnet run --project  ./src/go-bootcamp-challenge.csproj

restore:
		dotnet restore

test:	restore
		dotnet test