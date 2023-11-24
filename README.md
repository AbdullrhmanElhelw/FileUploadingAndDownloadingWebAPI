# FileUploadingAndDownloadingWebAPI
This ASP.NET Web API provides endpoints for seamless file uploading, downloading, listing, updating, and deleting operations. It simplifies the process of handling various file types, including image uploads. The API is built on the ASP.NET framework and leverages the Entity Framework for data storage.

## Endpoints:

### Upload a Single File

- **Endpoint:** `POST /api/File/Upload`
- **Request:**
  - Form Data: `file` (IFormFile)
- **Response:**
  - If successful, returns the ID of the uploaded file.

### Download a File

- **Endpoint:** `GET /api/File/{id}`
- **Request:**
  - Path Parameter: `id` (int)
- **Response:**
  - Downloads the file associated with the specified ID.

### List All Files

- **Endpoint:** `GET /api/File/List`
- **Response:**
  - Returns a list of filenames.

### Delete a File

- **Endpoint:** `DELETE /api/File/{id}`
- **Request:**
  - Path Parameter: `id` (int)
- **Response:**
  - Deletes the file associated with the specified ID.

### Update a File

- **Endpoint:** `PUT /api/File/{id}`
- **Request:**
  - Path Parameter: `id` (int)
  - Form Data: `file` (IFormFile)
- **Response:**
  - Updates the file associated with the specified ID.

### Upload an Image with Validation

- **Endpoint:** `POST /api/File/UploadImage`
- **Request:**
  - Form Data: `image` (IFormFile)
- **Response:**
  - If successful, returns the ID of the uploaded image.

### Upload Multiple Files

- **Endpoint:** `POST /api/File/UploadMultipleFiles`
- **Request:**
  - Form Data: `files` (List<IFormFile>)
- **Response:**
  - If successful, uploads multiple files.

## Getting Started:

1. Clone the repository.
   ```bash
   git clone https://github.com/yourusername/AspNetFileManagementWebAPI.git
```bash
  cd AspNetFileManagementWebAPI
  dotnet restore
  dotnet run

```bash
# Install the .NET 8 SDK
# Visit https://dotnet.microsoft.com/download/dotnet/8.0 to download and install the SDK
# Skip this step if you already have .NET 8 installed
dotnet --version

# Install Entity Framework Core packages
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

