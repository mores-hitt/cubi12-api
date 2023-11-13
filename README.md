# CUBI12 - API
API RESTful used as backend for Cubi12 software using .NET 7 and mySQL.

Cubi12 is (currently) an open source project to help students at UCN (Universidad Católica del Norte) at Chile to understand all the subjects they can take and their progress in the career.

## Prerequisites

- SDK [.NET 7](https://dotnet.microsoft.com/es-es/download/dotnet/7.0).
- Port 80 Available
- git [2.33.0](https://git-scm.com/downloads) or higher.
- [Docker](https://www.docker.com/) Is highly recommended to see the steps to install correctly docker on your machine: [Linux](https://docs.docker.com/desktop/install/linux-install/), [Windows](https://docs.docker.com/desktop/install/windows-install/) or [MacOs](https://docs.docker.com/desktop/install/mac-install/).


## Getting Started

Follow these steps to get the project up and running on your local machine:

1. Clone the repository to your local machine.

2. Navigate to the project directory.
   ```bash
   cd Backend
   ```

3. Inside the folder Cubitwelve exists a file called *.env.development* change their name to *.env* 

    **Note:** If you change some field you also need to update the DB_CONNECTION to match the database connection url provided to backend.
    ```bash
    DB_DATABASE=sampledb
    DB_USER=sample_user
    DB_PASSWORD=sample_password
    DB_ROOT_PASSWORD=root_password
    JWT_SECRET=secret_only_knewed_by_you
    DB_CONNECTION=server=localhost;user=sample_user;password=sample_password;database=sampledb  
    ```

4. Install project dependencies using dotnet sdk.
   ```bash
   dotnet restore
   ```

5. Setup the container for mySQL database, because the config file do not have the default name of docker-compose.yml the command needs to include *--file* flag
    ```bash
    docker-compose --file dev.yml up -d
    ```

5. Is recommended to wait 5 seconds and the run the project, thus the database structure finish to build before backend tries to connect.

    Either way, the backend tries until 10 times to connect if the database is not responding
    ```bash
    dotnet run
    ```

This will start the development server, and you can access the app in your web browser by visiting http://localhost:80.

## Use

To test the endpoints you can acces to OpenAPI Swagger interactive documentation at http://localhost:80/swagger/index.html

Also you can use [Postman](https://www.postman.com/) or another software to test the API.