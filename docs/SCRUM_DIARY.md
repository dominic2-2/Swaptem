# Scrum Diary - Swaptem

## Sprint 0 (Từ 02/02/2026 đến 08/02/2026)
**Mục tiêu Sprint:** Làm rõ nghiệp vụ, thiết kế hệ thống và dựng khung dự án (Scaffolding).

### Ngày: 02/02/2026 (Thứ Hai)
- **Đã làm:** 
    - Khởi tạo Repo Swaptem, thiết lập .gitignore (Visual Studio) và License MIT.
    - Xây dựng Product Backlog gồm 8 User Stories tập trung vào bài toán Escrow và Dispute.
- **Sẽ làm:** Phân tích luồng tiền (Money Flow) và định nghĩa các trạng thái đơn hàng.
- **Vấn đề:** Xác định phạm vi MVP (Minimum Viable Product) sao cho vừa đủ sức nặng để đi phỏng vấn, vừa kịp tiến độ hoàn thành trong 1 tháng.

---

### Ngày: 03/02/2026 (Thứ Ba)
- **Đã làm:** Thiết lập nhật ký dự án (Scrum Diary).
- **Sẽ làm:** Vẽ sơ đồ trạng thái đơn hàng (Order States) và cập nhật chi tiết (Refine) cho Backlog.
- **Vấn đề:** Cần làm rõ logic xử lý tiền khi có tranh chấp (Dispute) để đảm bảo tính công bằng.

---

### Ngày: 04/02/2026 (Thứ Tư)
- **Đã làm:**
    - Hoàn thiện sơ đồ nghiệp vụ "Transaction Lifecycle" (xử lý logic, tranh chấp, phạt).
    - Cập nhật chi tiết Acceptance Criteria cho các thẻ Backlog quan trọng (Escrow, Dispute).
- **Sẽ làm:**
    - Thiết kế cơ sở dữ liệu (ERD) cho các thực thể User, Wallet, Order.
    - Chốt kiến trúc dự án (Clean Architecture + CQRS).
- **Vấn đề:**
    - Logic tính nợ (Debt) khá phức tạp, cần thiết kế bảng Wallet khéo léo để tránh sai lệch tiền.

---

### Ngày: 05/02/2026 (Thứ Năm)
- **Đã làm:**
    - **Chốt thiết kế Database (Logical & Physical ERD):** Hoàn thiện sơ đồ quan hệ thực thể, xác định kiểu dữ liệu (GUID, Decimal, Nvarchar...).
    - **Thay đổi kiến trúc dòng tiền:** Quyết định chuyển từ mô hình "Ví ảo" sang "Thanh toán bán tự động" (Semi-Auto Payout) để giảm rủi ro pháp lý và kỹ thuật.
    - **Nâng cấp nghiệp vụ:** Thiết kế logic "3-Strikes Ban" (Tự động khóa), "Blacklist Ngân hàng" (Chặn dòng tiền rác) và "Redemption" (Cơ chế chuộc nợ để gỡ Block).
    - **Cập nhật Product Backlog:** Sửa đổi các thẻ User Story liên quan đến Payout, Admin Dashboard và Dispute để khớp với logic mới.
- **Sẽ làm:**
    - Khởi tạo Solution trong Visual Studio theo cấu trúc Clean Architecture (Domain, Application, Infrastructure, API).
    - Implement các Entity vào Code (C#).
- **Vấn đề:**
    - Logic truy vết nợ và kiểm toán (Accounting) rất phức tạp, đã giải quyết bằng cách tách bảng `TRANSACTION` (Payout & Debt_Deduction) và thêm bảng `BLOCKED_PAYOUT`.

---

### Ngày: 06/02/2026 (Thứ Sáu) đến 08/02/2026 (Chủ Nhật)
- **Đã làm:**
    - Không có (Dự án tạm dừng do Dev chính bận lịch phỏng vấn và việc cá nhân).
- **Sẽ làm:**
    - Quay lại làm việc vào Thứ Hai tuần sau (09/02).
    - Dồn task "Dựng khung dự án" sang Sprint 1.
- **Vấn đề:**
    - Thời gian eo hẹp, không hoàn thành mục tiêu Sprint 0 đúng hạn (Missed Sprint Goal).

---

**TỔNG KẾT SPRINT 0:**
- **Trạng thái:** KẾT THÚC (Failed Goal).
- **Lý do:** Chưa dựng được khung dự án (Scaffolding).
- **Hành động:** Chuyển toàn bộ phần Coding sang Sprint 1.

## Sprint 1 (Từ 09/02/2026 đến 15/02/2026)
**Mục tiêu Sprint:** Dựng khung dự án (Architecture), hoàn thiện Database và chức năng Authentication (Đăng ký/Đăng nhập).

### Ngày: 09/02/2026 (Thứ Hai)
- **Đã làm:**
    - Khởi tạo thành công Solution với Clean Architecture (Domain, Application, Infrastructure, API).
    - Cài đặt đầy đủ các gói NuGet (EF Core, MediatR...) phiên bản .NET 10.
    - **Hoàn thành 100% tầng Domain:** Code xong các Entity quan trọng (User, Product, Order) và các logic phức tạp (Transaction, BlockedPayout).
    - Bổ sung các Entity còn thiếu (Conversation, Message, Notification) để đảm bảo Project build không lỗi.
- **Sẽ làm:**
    - Cấu hình `ApplicationDbContext` trong tầng Infrastructure.
    - Thiết lập chuỗi kết nối (Connection String) tới SQL Server.
    - Chạy lệnh `Add-Migration` và `Update-Database` để sinh ra Database thực tế.
- **Vấn đề:**
    - Gặp chút trục trặc khi cài NuGet bằng dòng lệnh (CLI) do mạng timeout, đã khắc phục bằng cách dùng giao diện Visual Studio (Manage NuGet Packages).

---

### Ngày: 10/02/2026 (Thứ Ba)
- **Đã làm:**
    - Hoàn thiện file `SwaptemDbContext.cs` với đầy đủ các mối quan hệ phức tạp (Self-referencing Transaction, BlockedPayout, Conversation...).
    - Cấu hình bảo mật Connection String bằng **User Secrets** (tách biệt SQL Server cho Dev và PostgreSQL cho Deploy).
    - Cài đặt gói `Npgsql.EntityFrameworkCore.PostgreSQL` để hỗ trợ đa nền tảng.
    - Thực hiện Migration thủ công thành công cho cả 2 môi trường (SQL Server và PostgreSQL) để có Database chạy thử.
- **Sẽ làm:**
    - Refactor lại kiến trúc Database: Tách thành 2 DbContext con (`SqlDbContext` và `PostgresDbContext`) để giải quyết triệt để xung đột Migration Snapshot.
    - Bắt đầu code tầng Repository (Truy xuất dữ liệu).
- **Vấn đề:**
    - Gặp xung đột `ModelSnapshot` khi dùng chung 1 DbContext cho 2 loại Database.
    - Giải pháp tạm thời: Phải xóa Migration của DB này mới tạo được cho DB kia -> Tốn công sức và dễ sai sót. Cần fix triệt để vào ngày mai.

---

### Ngày: 11/02/2026 (Thứ Tư)
- **Đã làm:**
    - (Nghỉ) Giải quyết việc cá nhân và dọn dẹp nhà cửa đón Tết.
- **Sẽ làm:**
    - Quay lại xử lý vấn đề cấu hình Database và Migration.
- **Vấn đề:**
    - Tiến độ bị gián đoạn tạm thời do kế hoạch gia đình.

---

### Ngày: 12/02/2026 (Thứ Năm)
- **Đã làm:**
    - Tiếp tục khắc phục lỗi Migration snapshot giữa SQL Server và PostgreSQL.
    - Đánh giá lại kiến trúc: Nhận thấy việc duy trì đồng thời 2 hệ quản trị CSDL là dư thừa và gây phức tạp hóa hệ thống (Over-engineering).
    - **Quyết định chốt hạ:** Loại bỏ SQL Server, chỉ sử dụng duy nhất **PostgreSQL** (chạy trên Docker) cho cả môi trường Development và Production để đảm bảo tính đồng nhất.
- **Sẽ làm:**
    - Tái cấu trúc toàn bộ Solution sang mô hình Monorepo để quản lý tập trung cả Frontend và Backend.
- **Vấn đề:**
    - Tốn nhiều thời gian và công sức cho việc cấu hình sai hướng (hỗ trợ Multi-DB không cần thiết).

---

### Ngày: 13/02/2026 (Thứ Sáu) - "The Fix Day"
- **Đã làm:**
    - **Refactor Architecture:** Chuyển đổi thành công dự án sang cấu trúc **Nx Monorepo** (tích hợp .NET 10 API và Angular).
    - **Infrastructure:** Chuẩn hóa hạ tầng bằng Docker Compose để dựng PostgreSQL; kết nối và thực hiện Migration thành công từ Backend.
    - **Integration:** Cấu hình chính xác chính sách CORS; ứng dụng Frontend (Angular) đã thực hiện gọi API thành công tới Backend.
    - **Documentation:** Hoàn thiện bộ tài liệu kỹ thuật quan trọng bao gồm: Architecture Doc, Database Design và báo cáo Retrospective.
- **Sẽ làm:**
    - Triển khai code tính năng Xác thực người dùng (Auth: Register/Login).
- **Vấn đề:**
    - Phát hiện thiếu hụt quy trình Sprint 0 (thiếu tài liệu thiết kế và khung Frontend) dẫn đến việc phải dành trọn một ngày để bổ sung nền tảng.

---
