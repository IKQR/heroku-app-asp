FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY /*.csproj ./
RUN cd src; for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done; cd ..
RUN dotnet restore  

COPY ./src /app/src
WORKDIR /app/src/HerokuApplication.Web
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet HerokuApplication.Web.dll