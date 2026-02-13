# Software Architecture - Swaptem

## 1. Overview
Swaptem là nền tảng chợ trung gian (Escrow Marketplace) mua bán tài khoản game và sản phẩm số.
Hệ thống được xây dựng theo mô hình **Monorepo** để tối ưu hóa việc quản lý code và chia sẻ tài nguyên.

## 2. Technology Stack
- **Quản lý Monorepo:** Nx (v20+)
- **Frontend:** Angular (SCSS, Standalone Components)
- **Backend:** .NET 10 (Web API)
- **Database:** PostgreSQL (Dockerized)
- **Authentication:** JWT (JSON Web Tokens)

## 3. Backend Architecture (Clean Architecture)
Backend tuân thủ nghiêm ngặt nguyên lý Dependency Rule với 4 tầng:

### 3.1. Domain Layer (Core)
- Chứa Enterprise Logic và Entities.
- **Không phụ thuộc** vào bất kỳ tầng nào khác.
- Các Entity chính: `User`, `Order`, `Product`, `Transaction`.

### 3.2. Application Layer
- Chứa Application Logic (Use Cases).
- Sử dụng pattern **CQRS** (Command Query Responsibility Segregation) với thư viện **MediatR**.
- Chứa Interfaces (Abstractions) cho Infrastructure implement.

### 3.3. Infrastructure Layer
- Implement các giao tiếp bên ngoài (Database, Email, File Storage).
- Sử dụng **Entity Framework Core** với **PostgreSQL**.

### 3.4. API Layer (Presentation)
- Là entry point của ứng dụng.
- Chỉ làm nhiệm vụ nhận Request và trả về Response (thông qua MediatR).

## 4. Folder Structure (Nx)
```text
Swaptem/
├── apps/
│   ├── swaptem-web/       # Angular App
│   └── swaptem-api/       # .NET API Solution
├── libs/                  # Shared Libraries (UI, Interfaces)
├── docs/                  # Documentation
└── docker-compose.yml     # Infrastructure Setup