# RETROSPECTIVE (Giai đoạn Khởi động & Sprint 0)
**Thời gian thực tế:** 02/02/2026 - 13/02/2026
**Người thực hiện:** Fullstack Developer (Solo)

## 1. Nhìn lại (Overview)
Giai đoạn khởi động dự án kéo dài hơn dự kiến (2 tuần thay vì 1 tuần) do vướng lịch nghỉ Tết, phỏng vấn và các quyết định kỹ thuật phức tạp. Tuy nhiên, nền móng hiện tại đã rất vững chắc.

## 2. Những điều làm tốt (The Good)
- **Kiến trúc:** Đã thiết lập thành công **Clean Architecture** kết hợp **Nx Monorepo**. Đây là cấu trúc chuẩn Enterprise, dễ mở rộng cho Mobile sau này.
- **Công nghệ:** Chốt sử dụng **.NET 10** (Backend), **Angular** (Frontend) và **PostgreSQL** (Database) chạy trên **Docker**.
- **Tư duy:** Đã dũng cảm "đập đi xây lại" (bỏ Multi-DB, chuyển sang Nx) để tối ưu quy trình dài hạn thay vì cố đấm ăn xôi.

## 3. Những bài học (The Bad & Lessons)
- **Lỗi Over-engineering:** Việc cố hỗ trợ cả SQL Server và Postgres ngay từ đầu là sai lầm, gây lãng phí 2 ngày debug.
  -> *Bài học:* Keep It Simple, Stupid (KISS). Chọn 1 công nghệ tốt nhất và stick với nó.
- **Quản lý thời gian:** Các việc cá nhân (Tết, Phỏng vấn) làm nát lịch trình Sprint.
  -> *Bài học:* Cần trừ hao thời gian (Buffer time) nhiều hơn trong các Sprint tới.
- **Quy trình:** Bắt tay vào code khi chưa setup xong Frontend/Docs khiến phải dừng lại giữa chừng để fix.
  -> *Bài học:* Tuân thủ "Definition of Ready" trước khi code.

## 4. Cam kết cho Sprint 1 (Phần còn lại)
- Tập trung 100% vào nghiệp vụ (Business Logic): Đăng ký, Đăng nhập, JWT.
- Không sửa đổi kiến trúc hạ tầng nữa.