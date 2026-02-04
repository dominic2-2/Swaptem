# Scrum Diary - Swaptem

## Sprint 0 (Từ 02/02/2026 đến 08/02/2026)
**Mục tiêu Sprint:** Làm rõ nghiệp vụ, thiết kế hệ thống và dựng khung dự án (Scaffolding).

### Ngày: 02/02/2026 (Thứ Hai)
- **Đã làm:** - Khởi tạo Repo Swaptem, thiết lập .gitignore (Visual Studio) và License MIT.
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
