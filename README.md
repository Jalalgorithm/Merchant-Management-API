## Merchant API
This document provides comprehensive API documentation for the Merchant API. It details all available endpoints, their functionalities, required parameters, and expected responses, along with general information about authentication, error handling, and sample usage.

## Table of Contents

1.  [Introduction](#1-introduction)
2.  [Authentication](#2-authentication)
3.  [Error Handling](#3-error-handling)
4.  [Rate Limiting](#4-rate-limiting)
5.  [API Endpoints](#5-api-endpoints)
    *   [5.1. Create Merchant](#51-create-merchant)
    *   [5.2. Get All Merchants](#52-get-all-merchants)
    *   [5.3. Get Merchant by ID](#53-get-merchant-by-id)
    *   [5.4. Update Merchant](#54-update-merchant)
    *   [5.5. Delete Merchant by ID](#55-delete-merchant-by-id)
6.  [Sample Usage](#6-sample-usage)

---

## 1. Introduction


The Merchant API provides a set of endpoints for managing merchant information within the system. It follows a Clean Architecture approach with CQRS (Command Query Responsibility Segregation) pattern, leveraging MediatR for handling commands and queries.

## 📁 Project Structure (Clean Architecture)

```
├── src
│   ├── Application          # CQRS Handlers, DTOs, Validators, Interfaces
│   ├── Domain               # Entities, Enums, ValueObjects, Business Rules
│   ├── Infrastructure       # Persistence Layer, External Services
│   ├── WebApi               # API Controllers, DI, Middlewares
└── tests
    └── UnitTests            # xUnit or NUnit-based unit tests
```

## 🛠️ Tech Stack

* **.NET 8**
* **ASP.NET Core Web API**
* **MediatR** for CQRS
* **FluentValidation**
* **In-Memory EF Core** for database
* **Swagger / Swashbuckle**
* **AutoMapper**
* **Serilog** (Optional logging)
* **xUnit/NUnit** for testing

## 🚀 Getting Started

###  📦 Clone the Repository

```bash
git clone https://github.com/jalalgorithm/Merchant-Management-API.git
cd Merchant-Management-API
```

---

###  🧹 Prerequisites

Ensure you have the following installed:

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
* Visual Studio 2022+ or VS Code (with C# plugin)
* Git

---

###  🛠️ Build the Project

Using CLI:

```bash
dotnet build
```

Using Visual Studio:

* Open `YourSolution.sln`
* Restore NuGet packages
* Build the solution (Ctrl + Shift + B)

---

###  🧪 Run the Application

```bash
cd src/MerchantAPI.WebAPIServer
dotnet run
```



All API responses conform to a standard `ServiceResponse<T>` format:

```json
{
  "data": { /* The actual response data (type depends on endpoint) */ },
  "isSuccess": true,
  "message": "Operation successful."
}
```

In case of an error, `isSuccess` will be `false`, and `message` will contain details about the error. The `data` field might be `null` or an empty object.

## 2. Authentication

Based on the current project structure and provided codebase summary, **there is no explicit authentication or authorization mechanism implemented** within this specific microservice. It is assumed that authentication would be handled by an upstream service (e.g., an API Gateway) or is not yet in scope for this iteration of the API.

Therefore, all endpoints are currently accessible without any authentication tokens or credentials.

## 3. Error Handling

The API uses standard HTTP status codes to indicate the success or failure of a request, complemented by the `ServiceResponse` format for detailed messages.

*   **200 OK**: The request was successful.
*   **201 Created**: A new resource was successfully created.
*   **204 No Content**: A new resource has been successfully updated or deleted
*   **400 Bad Request**: The request was malformed, or validation failed. This typically includes issues like invalid input data, missing required fields, or business rule violations (e.g., invalid country). FluentValidation pipeline behavior ensures detailed error messages for invalid input.
*   **404 Not Found**: The requested resource could not be found (e.g., merchant with a given ID does not exist).
*   **500 Internal Server Error**: An unexpected error occurred on the server.

**Error Response Example (400 Bad Request - Validation Error):**

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Validation failed: \n - BusinessName: Business Name must be between 5 and 100 characters.\n - Email: 'Email' is not a valid email address."
}
```

**Error Response Example (404 Not Found):**

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Merchant not found."
}
```

## 4. Rate Limiting

Based on the provided project context, **no explicit rate limiting is implemented** within this API. Clients are currently not subject to rate limits for the number of requests they can make within a specific timeframe.

## 5. API Endpoints

### 5.1. Create Merchant

Creates a new merchant entry in the system.

*   **HTTP Method**: `POST`
*   **Path**: `/api/merchants`
*   **Description**: Creates a new merchant record with the provided details. Input data is validated for format and business rules (e.g., country existence).
*   **Authentication**: None

#### Parameters

*   **Body**: `application/json` (Required)
    *   `BusinessName` (string): The business name of the merchant. **Required**. Minimum 5, maximum 100 characters.
    *   `Email` (string): The email address of the merchant. **Required**. Must be a valid email format.
    *   `PhoneNumber` (string): The phone number of the merchant. **Required**. Must match E.164 format (e.g., `+12345678901`, `07911123456`).
    *   `Status` (string): The status of the merchant. **Required**. Must be one of: `"Pending"`, `"Active"`, `"Inactive"`.
    *   `Country` (string): The country of the merchant. **Required**. Validated against an external country validator service.

#### Request Example

```json
{
  "businessName": "Acme Corporation",
  "email": "contact@acmecorp.com",
  "phoneNumber": "+12345678901",
  "status": "Pending",
  "country": "USA"
}
```

#### Response Example (Success - 201 Created)

```json
{
  "data": {
    "id": 1,
    "createdAt": "2023-10-27T10:30:00.1234567Z"
  },
  "isSuccess": true,
  "message": "Merchant created successfully."
}
```

#### Response Example (Error - 400 Bad Request - Validation Error)

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Validation failed: \n - Country: 'Country' is not a valid country."
}
```

### 5.2. Get All Merchants

Retrieves a list of all merchants registered in the system.

*   **HTTP Method**: `GET`
*   **Path**: `/api/merchants`
*   **Description**: Fetches all merchant records.
*   **Authentication**: None

#### Parameters

*   None

#### Request Example

```
GET /api/merchants
```

#### Response Example (Success - 200 OK)

```json
{
  "data": [
    {
      "id": 1,
      "businessName": "Acme Corporation",
      "email": "contact@acmecorp.com",
      "phoneNumber": "+12345678901",
      "status": "Pending",
      "country": "USA",
      "createdAt": "2023-10-27T10:30:00.1234567Z"
    },
    {
      "id": 2,
      "businessName": "Globex Inc.",
      "email": "info@globex.net",
      "phoneNumber": "+447911123456",
      "status": "Active",
      "country": "UK",
      "createdAt": "2023-10-27T11:00:00.9876543Z"
    }
  ],
  "isSuccess": true,
  "message": "Merchants retrieved successfully."
}
```

#### Response Example (Success - 200 OK - No Merchants Found)

```json
{
  "data": [],
  "isSuccess": true,
  "message": "Null"
}
```

### 5.3. Get Merchant by ID

Retrieves a single merchant's details by their unique ID.

*   **HTTP Method**: `GET`
*   **Path**: `/api/merchants/{id}`
*   **Description**: Fetches a single merchant record using its unique identifier.
*   **Authentication**: None

#### Parameters

*   **Path**:
    *   `id` (integer): The unique identifier of the merchant. **Required**. Must be greater than 0.

#### Request Example

```
GET /api/merchants/1
```

#### Response Example (Success - 200 OK)

```json
{
  "data": {
    "id": 1,
    "businessName": "Acme Corporation",
    "email": "contact@acmecorp.com",
    "phoneNumber": "+12345678901",
    "status": "Pending",
    "country": "USA",
    "createdAt": "2023-10-27T10:30:00.1234567Z"
  },
  "isSuccess": true,
  "message": "Merchant retrieved successfully."
}
```

#### Response Example (Error - 404 Not Found)

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Merchant not found."
}
```

### 5.4. Update Merchant

Updates an existing merchant's details by their unique ID.

*   **HTTP Method**: `PUT`
*   **Path**: `/api/merchants/{id}`
*   **Description**: Updates one or more fields of an existing merchant identified by `id`. Only fields included in the request body will be updated. Validations apply to provided fields.
*   **Authentication**: None

#### Parameters

*   **Path**:
    *   `id` (integer): The unique identifier of the merchant to update. **Required**. Must be greater than 0.
*   **Body**: `application/json` (Required)
    *   `BusinessName` (string, optional): The new business name. If provided, must be 5-100 characters.
    *   `Email` (string, optional): The new email address. If provided, must be a valid email format.
    *   `PhoneNumber` (string, optional): The new phone number. If provided, must match E.164 format.
    *   `Status` (string, optional): The new status. If provided, must be one of: `"Pending"`, `"Active"`, `"Inactive"`.
    *   `Country` (string, optional): The new country. If provided, validated against an external country validator service.

#### Request Example

```json
{
  "businessName": "Acme Corp Renewed",
  "email": "support@acmecorp.com",
  "status": "Active"
}
```

#### Response Example (Success - 200 OK)

```json
{
  "data": {
    "id": 1,
    "createdAt": "2023-10-27T10:30:00.1234567Z"
  },
  "isSuccess": true,
  "message": "Merchant updated successfully."
}
```

#### Response Example (Error - 400 Bad Request - Validation Error)

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Validation failed: \n - Email: 'Email' is not a valid email address."
}
```

#### Response Example (Error - 404 Not Found)

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Merchant not found."
}
```

### 5.5. Delete Merchant by ID

Deletes a merchant from the system using their unique ID.

*   **HTTP Method**: `DELETE`
*   **Path**: `/api/merchants/{id}`
*   **Description**: Removes a merchant record permanently from the database.
*   **Authentication**: None

#### Parameters

*   **Path**:
    *   `id` (integer): The unique identifier of the merchant to delete. **Required**. Must be greater than 0.

#### Request Example

```
DELETE /api/merchants/1
```

#### Response Example (Success - 200 OK)

```json
{
  "data": 1,
  "isSuccess": true,
  "message": "Merchant deleted successfully."
}
```

#### Response Example (Error - 400 Bad Request - Validation Error)

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Validation failed: \n - Id: Id must be greater than 0."
}
```

#### Response Example (Error - 404 Not Found)

```json
{
  "data": null,
  "isSuccess": false,
  "message": "Merchant not found."
}
```

## 6. Sample Usage

Here are `curl` commands demonstrating how to interact with the Merchant API endpoints. Replace `http://localhost:5000` with your API's base URL.

### 6.1. Create Merchant

```bash
curl -X POST \
  http://localhost:5000/api/merchants \
  -H 'Content-Type: application/json' \
  -d '{
    "businessName": "Sample Merchant Ltd.",
    "email": "info@samplemerchant.com",
    "phoneNumber": "+15551234567",
    "status": "Pending",
    "country": "USA"
  }'
```

### 6.2. Get All Merchants

```bash
curl -X GET \
  http://localhost:5000/api/merchants
```

### 6.3. Get Merchant by ID

```bash
# Assuming merchant with ID 1 exists
curl -X GET \
  http://localhost:5000/api/merchants/1
```

### 6.4. Update Merchant

```bash
# Assuming merchant with ID 1 exists
curl -X PUT \
  http://localhost:5000/api/merchants/1 \
  -H 'Content-Type: application/json' \
  -d '{
    "businessName": "Updated Sample Merchant",
    "status": "Active"
  }'
```

### 6.5. Delete Merchant by ID

```bash
# Assuming merchant with ID 1 exists
curl -X DELETE \
  http://localhost:5000/api/merchants/1
```
