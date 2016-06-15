FROM microsoft/dotnet:latest
COPY bin/Debug/netcoreapp1.0/publish/ /root/

RUN apt-get update  
RUN apt-get install  sqlite3 libsqlite3-dev  

EXPOSE 5000/tcp
ENTRYPOINT dotnet /root/MoviesNetCore.dll