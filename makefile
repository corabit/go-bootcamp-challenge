build:  
		docker build -t go-bootcamp-challenge .

run:	
		docker run --rm -p 8080:80 --name go-bootcamp-challenge go-bootcamp-challenge

start:
		docker container start go-bootcamp-challenge

stop:
		docker container stop go-bootcamp-challenge

rm-container:
		docker container rm -f go-bootcamp-challenge

rm-image:
		docker image rm go-bootcamp-challenge
