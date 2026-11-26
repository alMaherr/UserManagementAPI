# User Management API

## Overview

The User Management API is an ASP.NET Core Web API developed for TechHive Solutions. The API allows HR and IT departments to manage user records through standard CRUD operations.

This project was enhanced using Microsoft Copilot to accelerate development, improve code quality, implement middleware, and assist with debugging and testing.

---

## Features

### User Management

- Create new users
- Retrieve all users
- Retrieve a specific user by ID
- Update existing users
- Delete users

### Validation

The API validates user input using Data Annotations:

- Required fields
- Email format validation
- String length restrictions

### Error Handling

The API handles unexpected exceptions through custom middleware and returns consistent JSON responses.

### Authentication

Requests require a valid bearer token.

Example:

```http
Authorization: Bearer secret-token
```

Invalid or missing tokens return:

```json
{
  "error": "Unauthorized"
}
```

### Logging

Custom logging middleware records:

- HTTP Method
- Request Path
- Response Status Code

Example Log:

```text
Method: GET, Path: /api/users, StatusCode: 200
```

---

## Project Structure

```text
UserManagementAPI
│
├── Controllers
│   └── UsersController.cs
│
├── Models
│   └── User.cs
│
├── Middleware
