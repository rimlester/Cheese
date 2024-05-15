#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS with-node
WORKDIR /src
RUN curl https://nodejs.org/dist/v18.18.0/node-v18.18.0-win-x64.zip --output node.zip
RUN tar -xf node.zip
USER ContainerAdministrator
RUN setx /M path "%path%;C:\src\node-v18.18.0-win-x64"
USER ContainerUser


FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cheese.Server/Cheese.Server.csproj", "Cheese.Server/"]
COPY ["cheese.client/cheese.client.esproj", "cheese.client/"]
RUN dotnet restore "./Cheese.Server/Cheese.Server.csproj"
COPY . .
WORKDIR "/src/Cheese.Server"
RUN dotnet build "./Cheese.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cheese.Server.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

#didn't get this to work - evidently the react app - which was running outside the image - is connecting to a non-exposed port.
#Could hardcode for a single run, but wanted to figure out what the issue was
#Also ran in to issues with https 
#FROM node:18 AS build-web
#COPY ./cheese.client/package.json /cheese.client/package.json
#COPY ./cheese.client/package-lock.json /cheese.client/package-lock.json
#WORKDIR /cheese.client
#RUN npm ci
#COPY ./cheese.client/ /cheese.client
#RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cheese.Server.dll"]
