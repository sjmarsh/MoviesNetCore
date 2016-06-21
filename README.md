##.Net Core
In powershell navigate to the main folder of the solution. </br>
Eg. Dev\MoviesNetCore\src\MoviesNetCore
</br>
</br>
Run the following command:
</br>
dotnet publish
</br>
</br>
This should create the following folder structure in bin. </br>
\Debug\netcoreapp1.0\publish
</br>
The Docker file can reference this path when copying the binaries for the application.

##Docker
**ssh to the dev folder**</br>
NOTE: Development folder in Windows has been mounted into the docker vm. See [http://www.developmentalmadness.com/2016/03/05/docker-permanently-mount-a-virtualbox-shared-folder/](http://www.developmentalmadness.com/2016/03/05/docker-permanently-mount-a-virtualbox-shared-folder/ "Permanently Mounting a Virtualbox Shared Folder") </br>
</br>
docker-machine ssh default </br> 
cd /mnt/dev/

**Build**</br>
  docker build -t movies-net-core .

**Run**</br>
  docker run -it -p 5000:5000 movies-net-core

##Sqlite
Sqlite needs to be added into the docker image.  More info here: </br>
[http://blog.opinionatedapps.com/using-sqlite3-inside-an-aspnet5-docker-image-as-web-api-persistence-store/](http://blog.opinionatedapps.com/using-sqlite3-inside-an-aspnet5-docker-image-as-web-api-persistence-store/)

## Other Links
[https://medium.com/trafi-tech-beat/running-net-core-on-docker-c438889eb5a#.hr092welt](https://medium.com/trafi-tech-beat/running-net-core-on-docker-c438889eb5a#.hr092welt)
</br>
[http://blog.pavelsklenar.com/5-useful-docker-tip-and-tricks-on-windows/](http://blog.pavelsklenar.com/5-useful-docker-tip-and-tricks-on-windows/)
</br>
[https://xunit.github.io/docs/getting-started-dotnet-core.html](https://xunit.github.io/docs/getting-started-dotnet-core.html)
</br>
[https://docs.asp.net/en/latest/testing/unit-testing.html](https://docs.asp.net/en/latest/testing/unit-testing.html)
</br>
[http://dotnetliberty.com/index.php/2016/02/22/moq-on-net-core/](http://dotnetliberty.com/index.php/2016/02/22/moq-on-net-core/)