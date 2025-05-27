# TaskManagementAPI

TaskManagementAPI User Guide

Base URL:
https://localhost:7180/api

-----------------------------------------------------------
1. Authentication — Login

Endpoint:
POST /Auth/login

Description:
Authenticate with username and password to get a JWT token.

Request Headers:
Content-Type: application/json
Accept: */*

Request Body (JSON):
{
  "username": "admin",
  "password": "admin"
}

Response (200 OK):
{
  "token": "your_jwt_token_here"
}

Notes:
- Use the token in Authorization header for other requests:
  Authorization: Bearer your_jwt_token_here

-----------------------------------------------------------
2. Create a Task

Endpoint:
POST /Task

Description:
Create a new task.

Request Headers:
Authorization: Bearer your_jwt_token_here
Content-Type: application/json
Accept: */*

Request Body (JSON):
{
  "title": "Web",
  "description": "This task is to create the API.",
  "assignedUserId": 1
}

Response (200 OK):
{
  "id": 9,
  "title": "Web",
  "description": "This task is to create the API.",
  "assignedUserId": 1,
  "assignedUser": null,
  "comments": []
}

-----------------------------------------------------------
3. Get Task By ID

Endpoint:
GET /Task/{id}

Description:
Get details of a task by its ID.

Request Headers:
Authorization: Bearer your_jwt_token_here
Accept: */*

URL Parameter:
id — Task ID (integer)

Example Request:
GET /Task/2

Response (200 OK):
{
  "id": 2,
  "title": "Create Task Management API",
  "description": "This task is to create the API.",
  "assignedUserId": 3,
  "assignedUser": null,
  "comments": []
}

-----------------------------------------------------------
4. Update Task

Endpoint:
PUT /Task/{id}

Description:
Update a task by its ID.

Request Headers:
Authorization: Bearer your_jwt_token_here
Content-Type: application/json
Accept: */*

URL Parameter:
id — Task ID (integer)

Request Body (JSON):
{
  "id": 2,
  "title": "Create Task Management API",
  "description": "This task is to create the API.",
  "assignedUserId": 3
}

Response:
204 No Content (success)

-----------------------------------------------------------
5. Delete Task

Endpoint:
DELETE /Task/{id}

Description:
Delete a task by its ID.

Request Headers:
Authorization: Bearer your_jwt_token_here
Accept: */*

URL Parameter:
id — Task ID (integer)

Response:
204 No Content (success)

-----------------------------------------------------------
6. Get Tasks by User ID

Endpoint:
GET /Task/user/{userId}

Description:
Get all tasks assigned to a specific user.

Request Headers:
Authorization: Bearer your_jwt_token_here
Accept: */*

URL Parameter:
userId — User ID (integer)

Example Request:
GET /Task/user/3

Response (200 OK):
[
  {
    "id": 5,
    "title": "Create API and web",
    "description": "This task is to create the API.",
    "assignedUserId": 3,
    "assignedUser": null,
    "comments": []
  },
  {
    "id": 6,
    "title": "API and web",
    "description": "This task is to create the API.",
    "assignedUserId": 3,
    "assignedUser": null,
    "comments": []
  }
]

-----------------------------------------------------------
How to use these APIs:

1. Login to get your JWT token.
2. Pass the token as Authorization header for all other requests:
   Authorization: Bearer <token>
3. Follow the JSON request formats exactly.
4. Use correct HTTP methods: POST, GET, PUT, DELETE.
5. Check HTTP response codes:
   - 200 OK = success + response data
   - 204 No Content = success no data
   - 400 Bad Request = input invalid
   - 401 Unauthorized = login/token issue
   - 404 Not Found = resource missing

---

End of Guide


Debugging Fixes for TaskService.cs

1. Changed return types from Task<Task> to Task<TaskItem> and List<Task> to Task<List<TaskItem>>.
2. Used async/await properly for asynchronous calls to EF Core.
3. Replaced _dbContext.Tasks with _dbContext.Set<TaskItem>() for proper DbSet access.
4. Wrapped EF Core calls in async methods to avoid blocking the main thread.
