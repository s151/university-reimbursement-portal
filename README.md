# 🏛️ University Reimbursement Portal

A full-stack web application that allows university employees to submit reimbursement claims and enables admins to review, approve, or reject those claims. Built with Angular (frontend) and ASP.NET Core (backend), backed by SQL Server.

---

## 📂 Project Structure

```
University_Claims_Frontend/    --> Angular frontend application
University_Claims_Backend/     --> ASP.NET Core Web API backend
```

---

## ✅ Features Implemented

- 🔐 Login and Registration system for employees
- 🧾 Submit new reimbursement with:
  - Employee Type
  - Date of Purchase
  - Reimbursement Amount
  - Description of Purchase
  - Receipt Upload
- 👩‍💼 Admin Panel to:
  - View all submissions
  - Approve or reject reimbursements
  - View user details
- 📥 File upload & download (receipts)
- 🧠 Role-based access: Admin vs Employee
- 📅 Real-time date capture and status tracking
- ✨ Polished UI with Bootstrap and custom SCSS

---

## 💻 Prerequisites

- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server + SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

---

## 🔧 Backend Setup – `University_Claims_Backend`

1. **Setup SQL Server**
   - Open SQL Server Management Studio (SSMS)
   - Execute the script `claimsmgmt.sql` to create:
     - `claimsdb` database
     - Tables: `members`, `claims`, `documents`
     - Inserts default Admin user:
       ```
       Email: admin
       Password: admin
       ```

2. **Run the Backend**
   ```bash
   cd University_Claims_Backend
   dotnet clean
   dotnet build
   dotnet run
   ```

3. **Verify it's running**
   - Navigate to: [http://localhost:5255](http://localhost:5255)
   - Test endpoint: `/api/v1/members/validate`

---

## 🌐 Frontend Setup – `University_Claims_Frontend`

1. **Install dependencies**
   ```bash
   cd University_Claims_Frontend
   npm install
   ```

2. **Start Angular development server**
   ```bash
   ng serve
   ```

3. **Visit in Browser**
   - Go to: [http://localhost:4200](http://localhost:4200)
   - If 4200 is in use, Angular will prompt to use another port (allow it).

---

## 🧪 Default Credentials

| Role      | Email  | Password |
|-----------|--------|----------|
| Admin     | admin  | admin    |
| Employee  | Create via Register form |

---

## ⚠️ Troubleshooting

- **Port in use**: Let Angular choose another port or free the port using Task Manager.
- **SQL errors**: Ensure SQL Server is running, and `claimsdb` exists.
- **CORS issues**: Handled in backend with `[EnableCors]` policy.
