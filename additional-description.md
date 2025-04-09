# 💬 Additional Notes on Design & Implementation

---

## a. Assumptions Made During Implementation

- **Authentication and Role Management Are Essential**  
  Though not explicitly asked, I assumed authentication would be vital. I implemented login/registration and role-based access so admins can review/approve submissions.

- **Reimbursement Workflows Mirror Approval Systems**  
  Assumed a review process was needed, so I added functionality for admins to approve or reject with status, rejection reasons, and final amount.

- **Simplicity in Schema with Smart Reuse**  
  I reused schema fields like `vtype`, `vno`, and `model` with relabeled UI meaning (e.g., “Vehicle Type” → “Employee Type”) to avoid backend changes.

- **Single File Upload Meets Requirements Efficiently**  
  The prompt required only one document, so I removed multi-document logic and supported clean single-file uploads.

---

## b. Problems Faced and How I Solved Them

- **Port Conflicts on Localhost**  
  Angular's default port 4200 was in use. I enabled dynamic port switching and updated the launch setup.

- **SQL Server Connection Issues**  
  Faced issues with SQL Server instance recognition. I corrected it using `.\SQLEXPRESS` and enabled TCP/IP and named pipes.

- **Preserving Backend Logic While Adapting Labels**  
  Instead of modifying schema, I applied relabeling strictly in the UI.

- **Form Validation and Reset Handling**  
  Managed Angular's form states via proper `FormGroup` resets and `touched/dirty` checks.

---

## c. Highlights in Code and Development Practices

- **Component Modularity and Abstraction**  
  Angular structure follows modular principles with dedicated services, route guards, and clean data handling.

- **Secure, Clean Backend**  
  ASP.NET Core Web API follows REST principles, uses DTOs, Entity Framework, and input validations.

- **UX and Styling Enhancements**  
  Crafted clean UI with Bootstrap/SCSS — ensuring responsiveness and minimal distraction.

- **Real-Time Status Feedback**  
  Clear tracking of reimbursement status with conditional UI for different roles.

- **Well-Structured Development Process (Single Commit Note)**  
  Although the final commit was consolidated, development was structured across setup, login, reimbursement workflows, styling, and testing. In a production environment, I follow granular commits, feature branches, and PR cycles.

---