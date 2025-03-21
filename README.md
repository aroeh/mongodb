# mongodb
Basic reference repo for MongoDb libraries and classes


## Demonstrated Features
- Clean Architecture concept
- Generic class to handle MongoDB Specific operations and generic return types

# Dependencies
- MongoDB
- Docker
- Docker Compose V2

# Getting Started
This project has a dependency on MongoDB.  You can either use a deployed MongoDB Atlas instance and a connection to connect, or you can use a containerized instance of MongoDB.

View the MongoService.cs file and review the constructor.  Identify how you will be retrieving your connection string and either comment/uncomment the lines present or alter the code.

This project is locally setup to use a MongoDB Docker Container.  The connection string is setup both in the docker-compose.yaml as well as in the launchSettings.json profiles via Environment Variables.  If you choose to use secrets, you will need to update the code and remove the Environment variables and change the MongoService to use the secrets location.

## MongoDB Atlas
1. Signup for MongoDB if you do not already have an account - Use the free tier of the service
2. Create a new project and database
3. Get the connection string to the database and store somewhere secure, ex: local secrets config file
4. Create a new collection in the database
5. Build and Run the API
6. Use .http files or Postman to send requests to the API

## MongoDB Container
1. Build all images and containers from the docker-compose.yaml file
2. Run the containers using docker-compose.yaml
3. Use .http files or Postman to send requests to the API


# Run the Solution
The easiest way to run this solution is to use docker compose as that will build the api project and provide containers for the data.  But there are other options as well.


## API Dockerfiles
There are 2 Dockerfiles present in the WebApiControllers project:
- Dockerfile
- Dockerfile_NoBuild

> Dockerfile is the initial setup default within the repository.

Each one demonstrates a different approach and potential use case.

### Dockerfile
Dockerfile is typically the default kind of file that Visual Studio auto generates with adding container support to a project.  
This example handles building the solution in a base image and then publishing the code to a runtime image.
This could be useful when wanting to debug and letting the docker runtime handle all of the work, or if you don't want to manually build and publish code before spinning up a new image and container.

### Dockerfile_NoBuild
This is a much smaller and much more simple docker file.  It requires published code to have already been produced to copy into the runtime image.
The Docker build and container spin up is much faster since it doesn't have to build the solution in the image itself.  
This scenario is useful in pipeline scenarios where the code may have already been built and published by prior tasks in a job.

To use this docker file in the solution, do the following:

1. In a command line, navigate to the directory containing the WebApiControllers.csproj
```
cd <path>\WebApiControllers
```

> Alter the path variable to match your local environment

2. Build the project either at the project or solution level
```
dotnet build
```

3. Publish the code into a directory using the Release configuration
```
dotnet publish WebApiControllers.csproj -c Release -o publish /p:UseAppHost=false
```

> This creates a new directory at `<path>\WebApiControllers\publish`

4. Update the docker-compose.yaml section for webapi.
    - Change the value of build.docker from WebApiControllers/Dockerfile to `WebApiControllers/Dockerfile_NoBuild`


## Docker Compose
1. Optional - build all containers in the compose yaml
```
docker compose build
```
> To build a specific container use `docker compose build <service-name>`

2. Compose up the containers
```
docker compose up
```
> If you do not want to debug, the add the -d parameter.  `docker compose up -d`
> docker compose up will also build all images if they do not exist, so step 1 is optional

3. Use an http client like Postman or the http files in Visual Studio to send requests to the API

4. Stop the containers when done with testing (or leave them running)
```
docker compose stop
```

> Use the start command to start the containers again
```
docker compose start
```

### Clean Up
Once containers are no longer needed you can remove them all using the compose down command
```
docker compose down
```

> Images can also be deleted using the compose down command
```
docker compose down --rmi "all"
```

## Docker
1. Pull the mongo db image
```
docker pull mongo
```

2. Build and Run the mongo db container
```
docker run -d -p 27017:27017 -e "MONGO_INITDB_ROOT_USERNAME=mongoUser" -e "MONGO_INITDB_ROOT_PASSWORD=mongoPassword" --name mongoLocal mongo
```
> Replace values for MONGO_INITDB_ROOT_USERNAME, MONGO_INITDB_ROOT_PASSWORD, and --name to those of your choosing if you prefer.  But note them as they are needed for the connection string in the next step

3. Build the API Project Image
```
docker build -t my_api_image -f Dockerfile .
```
> Docker Context will vary depending on where you run the command.  This command assumes that it is being run from the same path containing the Dockerfile.  ie: "<PATH>\WebApiControllers\"

4. Run the Api image and container
```
docker run -d -p 5112:80 -e "ASPNETCORE_ENVIRONMENT=Development" -e "MONGODB_CONN=mongodb://mongoUser:mongoPassword@mongoLocal:27017" -e "ASPNETCORE_URLS=http://+:80" --name my_api_container my_api_image
```

> This repo is not demonstrating security for the mongo db admin user or connection strings.  The best practice would be to store the credentials in a secure vault and retrieve them from the vault.

5. Create a docker network
```
docker network create my_network
```

6. Add the mongo db and api containers to the network
```
docker network connect mongoLocal
```

```
docker network connect my_api_container
```

6. Test the api using an http client like Postman or Visual Studio and .http files


## Containers and IDE
1. Create and use the Mongo DB container
> You can use either the docker or docker compose commands
> If using docker compose, you may need to pause the api container

2. Using an IDE of your choice, select a profile to use from the launchSettings.json

3. Run and/or debug the solution
> If you set a different user name and password for the Mongo DB container, then you will also need to update the environment variable in your launchSettings.json profile



# References
- [MongoDB](https://www.mongodb.com/)
- [MongoDb Docker](https://hub.docker.com/_/mongo)
- [Docker Compose CLI](https://docs.docker.com/compose/reference/)
- [Docker Compose Repo](https://github.com/docker/awesome-compose/tree/master)
- [Dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/)