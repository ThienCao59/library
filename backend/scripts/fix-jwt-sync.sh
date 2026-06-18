#!/bin/bash
# Đồng bộ JWT giữa Identity (N3) và Catalog/Circulation (N1/N2).
# Triệu chứng: login OK nhưng /api/catalog/* và /api/circulation/* trả 401.
set -euo pipefail

cd "$(dirname "$0")/.."

JWT_SECRET="Your_Super_Secret_Key_For_JWT_Validation_Needs_To_Be_Long_Enough"
JWT_ISSUER="IdentityReportService"
JWT_AUDIENCE="LibraryMicroservices"

echo "=== Rebuild & restart Identity + Gateway (JWT đồng bộ) ==="
docker compose up -d --build identity-service api-gateway

echo "=== Restart Catalog (N1) với JWT env ==="
docker compose up -d catalog-service

echo ""
echo "=== N2 Circulation: chạy container với cùng JWT env ==="
echo "Ví dụ (tên container/network tùy deploy N2):"
cat <<EOF
docker run -d --name library_circulation_service \\
  --network library_net \\
  -p 5082:8080 \\
  -e JwtSettings__Secret=${JWT_SECRET} \\
  -e JwtSettings__Issuer=${JWT_ISSUER} \\
  -e JwtSettings__Audience=${JWT_AUDIENCE} \\
  <image-n2-circulation>:latest
EOF

echo ""
echo "=== Kiểm tra nhanh (cần user/pass thật) ==="
echo "GATEWAY=http://163.223.210.87:5000 USER=admin PASS='...' bash scripts/verify-jwt-across-services.sh"
echo ""
echo "Sau khi sửa: user phải đăng xuất / xóa localStorage và đăng nhập lại."
