# CUBI12 - API
API RESTful used as backend for Cubi12 software using .NET 7 and MSSql.

Cubi12 is (currently) an open source project to help students at UCN (Universidad Cat�lica del Norte) at Chile to understand all the subjects they can take and their progress in the career.

## Prerequisites

- SDK [.NET 7](https://dotnet.microsoft.com/es-es/download/dotnet/7.0).
- Port 80 Available
- git [2.33.0](https://git-scm.com/downloads) or higher.
- [Docker](https://www.docker.com/) **Note**: If you do not have installed is highly recommended to see the steps to correctly install docker on your machine with [Linux](https://docs.docker.com/desktop/install/linux-install/), [Windows](https://docs.docker.com/desktop/install/windows-install/) or [MacOs](https://docs.docker.com/desktop/install/mac-install/).


## Getting Started

Follow these steps to get the project up and running on your local machine:

1. Clone the repository to your local machine.

2. Navigate to the root folder.
   ```bash
   cd Backend
   ```

3. Inside the project you will see 2 folders: Cubitwelve and Cubitwelve.tests, navigate to the first.
    ```bash
    cd Cubitwelve
    ```

4. Inside the folder Cubitwelve create a file and call it .env then fill with the following example values.
    ```bash
    MSSQL_SA_PASSWORD=MyStrongPassword123@
    JWT_SECRET=secret_only_knewed_by_yourself_and_nobody_else
    DB_CONNECTION=Server=localhost,5434;Database=master;User Id=sa;Password=MyStrongPassword123@;TrustServerCertificate=true;
    ```
    **Note1:** If you decide to change MSSQL_SA_PASSWORD review the [rules](https://hub.docker.com/_/microsoft-mssql-server) assigned to that Environment Variable
    
    **Note2:** If you change MSSQL_SA_PASSWORD you also need to update the DB_CONNECTION to match the Password parameter connection url provided to backend.
    
    **Note3**: If you change JWT_SECRET review [Padding](https://www.rfc-editor.org/rfc/rfc4868#page-5) of HmacSha256 Algorithm to avoid Runtime exceptions because of short secret.

5. Install project dependencies using dotnet sdk.
   ```bash
   dotnet restore
   ```

6. Setup the container for mySQL database, because the compose file have the name **dev.yml** the command needs to include *--file* flag
    ```bash
    docker-compose --file dev.yml up -d
    ```

7. Is recommended to wait 5 seconds and the run the project, thus the database structure finish to build before backend tries to connect.

    Either way, the backend tries until 5 times to connect if the database is not responding
    ```bash
    dotnet run
    ```

This will start the development server, and you can access the app in your web browser by visiting http://localhost:80.

## Use

To see the endpoints you can access to OpenAPI Swagger documentation at http://localhost:80/swagger/index.html

Also you can use [Postman](https://www.postman.com/) or another software to use the API.

## Database Persistence

The database container do not have a volume assigned, thus if you stop the container all the information will be deleted.

This behaviour is adopted because the Db container is designed only for development purposes.

## Testing

The project uses [xUnit](https://xunit.net/) as testing framework and [FluentAssertions](https://fluentassertions.com/) to improve readability, to run all the tests run the following commands:

1. If you are inside *Cubitwelve* folder go to root folder
    ```bash
    # Only if you are inside Cubitwelve folder
    cd ..
    ```
2. Now you are on the root folder, run the tests
    ```bash
    dotnet test
    ```