# ✅ Todo App

A full-stack **Task Management (Todo)** application built with **C#
ASP.NET Core Web API** for the backend and **React + Vite + TypeScript**
for the frontend.\
This project allows users to register, log in using **JWT
authentication**, and manage their personal todos efficiently.\
The UI is designed with **Material UI** for a modern and responsive
experience.

------------------------------------------------------------------------
## App Pages
<table>
  <thead>
    <tr>
      <th>Page</th>
      <th>Description</th>
      <th>Screenshot</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><b>🏠 Register Page</b></td>
      <td>Users can create a new account with a username, email, password, and password confirmation.</td>
      <td><img src="./screenshots/register.png" alt="Register Page" width="400"/></td>
    </tr>
    <tr>
      <td><b>🔐 Login Page</b></td>
      <td>Users can log in securely using their credentials. </td>
      <td><img src="./screenshots/login.png" alt="Login Page" width="400"/></td>
    </tr>
    <tr>
      <td><b>✅ Todo List Page</b></td>
      <td>Displays all tasks with title, description, and due date. Completed tasks appear with a strikethrough and checkbox.</td>
      <td><img src="./screenshots/todo.png" alt="Todo List Page" width="400"/></td>
    </tr>
  </tbody>
</table>


## 🚀 Features

### 🔐 Authentication

-   **JWT-based login & registration**
-   Secure password handling and token validation
-   Authorization middleware for protected routes

### 📝 Todo Management

-   Add, update, delete, and mark tasks as completed
-   Each todo includes:
    -   **Title**
    -   **Description**
    -   **Due date**
-   Completed tasks are displayed with strikethrough styling

### 💻 Frontend (React + Vite + TypeScript)

-   Built with **Vite** for fast development and build performance\
-   **Material UI** for clean, consistent design\
-   Reusable components for Login, Register, and TodoList\
-   Responsive layout and intuitive navigation (Login \| Register \|
    Todos)

### ⚙️ Backend (C# ASP.NET Core Web API)

-   RESTful API endpoints for user and todo operations\
-   JWT authentication for secure access\
-   Entity Framework Core for database management\
-   CORS configured to allow frontend-backend communication
