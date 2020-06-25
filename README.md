# WordsCloudCodeTest
The project is to fetch words in a website and showed in a web based words cloud. Meanwhile, top 100 word with its' frequency are stored into the database and then be showed in browser.

To find out details, please go to sample website: http://jasonqu1.eastus.cloudapp.azure.com:32768/

# How to run?

1. Clone the code to local.

2. In root dir, which is "WordsCloudCodeTest\\DockerTest3" dir, run cmd command "dotnet ef database update" to install database locally.

3. In front-end code dir, which is "WordsCloudCodeTest\\DockerTest3\ClientApp", run cmd command "npm install" to install front-end dependencies

4. In clientapp, "npm install"

5. In root dir, run "dotnet run" to start the program.

6. In browser, go to "https://localhost:7001".

   

# Features



## Back-end

1. Back-end construction

   ![](https://github.com/fishinsea2014/WordsCloudCodeTest/blob/master/Documents/back_end_structure.jpg)

2. Swagger

   All the APIs are presented in swagger. Please go to "https://hostname/swagger", or "http://jasonqu1.eastus.cloudapp.azure.com:32768/swagger"

3. Utilise techs of .Net core 3.1, Swagger, HtmlAgility, Salted Hash, reftful APIs.



## Front-end

1. Front-end structure

   ![](https://github.com/fishinsea2014/WordsCloudCodeTest/blob/master/Documents/Front_end_structure.jpg)

2. Utilise technologies of Angular 9, Rxjs and Angular material

## Devops

1. Dockerize the application into a docker image.
2. Publish the application on Azure in a Ubuntu virtual machine with docker.
3. Utilise Azure SQL Server as cloud database.
