FROM microsoft/dotnet:1.0.1-runtime
COPY bin/Debug/netcoreapp1.0/publish/ /root/

RUN apt-get update  
RUN apt-get -y install  sqlite3 libsqlite3-dev  

EXPOSE 5000/tcp
ENTRYPOINT dotnet /root/MoviesNetCore.dll