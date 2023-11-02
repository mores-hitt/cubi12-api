# CUBI12 - API
API RESTful used as backend for Cubi12 software using .NET 7 and mySQL.

Cubi12 is (currently) an open source project to help students at UCN (Universidad Católica del Norte) at Chile to understand all the subjects they can take and their progress in the career.

## Prerequisites

- SDK [.NET 7](https://dotnet.microsoft.com/es-es/download/dotnet/7.0).
- Port 5000 Available
- git [2.33.0](https://git-scm.com/downloads) or higher.
- [Docker](https://www.docker.com/) Is highly recommended to see the steps to install correctly docker on your machine: [Linux](https://docs.docker.com/desktop/install/linux-install/), [Windows](https://docs.docker.com/desktop/install/windows-install/) or [MacOs](https://docs.docker.com/desktop/install/mac-install/).


## Getting Started

Follow these steps to get the project up and running on your local machine:

1. Clone the repository to your local machine.

2. Navigate to the project directory.
   ```bash
   cd Backend
   ```
3. Change directory to the "Cubitwelve" folder, where the main application code is located.
   ```bash
   cd Cubitwelve
   ```

4. Inside the folder Cubitwelve exists a file called *.env.development* change their name to *.env* and then fill the fields with the right values, this is an example:
    ```bash
    DB_USER=my_epic_user
    DB_PASSWORD=my_secret_password
    DB_DATABASE=my_db
    DB_ROOT_PASSWORD=my_secret_root_password
    ```
    You can use whatever credentials you want

4. Install project dependencies using dotnet sdk.
   ```bash
   dotnet restore
   ```

5. Setup the container for mySQL database.
    ```bash
    docker-compose up
    ```

5. Run the project 
    ```bash
    dotnet run
    ```

This will start the development server, and you can access the app in your web browser by visiting http://localhost:5000.

## Use

To test the endpoints you can acces to OpenAPI Swagger interactive documentation at http://localhost:5000/swagger/index.html

Also you can use [Postman](https://www.postman.com/) or another software to test the API.