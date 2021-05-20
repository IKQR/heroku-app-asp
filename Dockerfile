ARG ConnectionStrings__Default

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app/
COPY ./*.sln ./

COPY . . 
RUN cd src; for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done; cd ../

RUN dotnet restore  

COPY ./src /app/src
WORKDIR /app/src/HerokuApplication.Web

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app/

COPY --from=build-env /out .

ENV ConnectionStrings__Default
#ENV ConnectionStrings__Default="Host=sql11.freesqldatabase.com;Database=sql11413514;User=sql11413514;Password=2nuNQTbI1r;Port=3306"

CMD exec ./HerokuApplication.Web --urls http://+:$PORT