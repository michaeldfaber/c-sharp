# Docker Hello World

A bare minimum Docker proof of concept using .NET Core.

This repository contains a simple .NET Core Web API (generated using the `dotnet new webapi` command) and instructions on how to get it running on a Docker container.

### Installing Docker

Download Docker Desktop for Windows or Mac here:
https://hub.docker.com/?overlay=onboarding

Download Docker Desktop for Linux here:
https://docs.docker.com/v17.12/install/

You will need to enable virtualization on your machine. You can check to see whether or not you already have virtualization enabled by checking the preformance tab on the task manager (Windows):

![](/ReadmePictures/taskmanagervirtualization.png)

You can verify your installation by running the `docker version` command:

![](/ReadmePictures/dockerversionoutput.PNG)

If your virtualization is enabled and you see a similar input you are ready to continue.

### Create the Container

Run a `docker build -t dockerhelloworldimage .` command to build your Docker image from a Dockerfile. This will run through all 10 steps in the Dockerfile. Take a look at the Dockerfile included in this repository as well as the output for more detail on what each step is doing. Note that `docker build` requires the name provided to be lowercase.

Run a `docker run -d -p 3000:80 --name dockerhelloworldcontainer dockerhelloworldimage`. `docker run` combines the `docker container create` and `docker container start` commands into one. This will create and start a container named dockerhelloworld using the image we built named dockerhelloworldimage.

Once that has succeeded, run a `docker container ls -a` command to see that your container has been created and that it is running:

If the container was successfully created but it is not running, `docker logs dockerhelloworldcontainer` might give you some information you can use to troubleshoot.

Make an HTTP GET request to http://localhost:3000/api/values and your .NET Core 3.0 Web API running in a simple Docker container:

![](/ReadmePictures/curllocalhost.PNG)