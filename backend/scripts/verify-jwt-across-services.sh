#!/bin/bash
# Xác minh JWT hoạt động xuyên N3 → N1/N2 qua Gateway.
# Usage: GATEWAY=http://163.223.210.87:5000 USER=admin PASS='Admin@123' ./verify-jwt-across-services.sh
set -euo pipefail

GATEWAY="${GATEWAY:-http://localhost:5000}"
USER="${USER:?Set USER}"
PASS="${PASS:?Set PASS}"

login_json=$(curl -sS -X POST "$GATEWAY/api/identity/Auth/login" \
  -H "Content-Type: application/json" \
  -d "{\"Username\":\"$USER\",\"Password\":\"$PASS\"}")

TOKEN=$(echo "$login_json" | sed -n 's/.*"accessToken"[[:space:]]*:[[:space:]]*"\([^"]*\)".*/\1/p')
if [[ -z "$TOKEN" ]]; then
  TOKEN=$(echo "$login_json" | sed -n 's/.*"AccessToken"[[:space:]]*:[[:space:]]*"\([^"]*\)".*/\1/p')
fi

if [[ -z "$TOKEN" ]]; then
  echo "LOGIN FAILED: $login_json"
  exit 1
fi

echo "Login OK (token length: ${#TOKEN})"

check() {
  local label="$1"
  local path="$2"
  local code
  code=$(curl -sS -o /dev/null -w "%{http_code}" -H "Authorization: Bearer $TOKEN" "$GATEWAY$path")
  echo "$label: HTTP $code"
  if [[ "$code" == "401" ]]; then
    echo "  -> JWT chưa đồng bộ giữa Identity và service đích"
    return 1
  fi
  return 0
}

FAIL=0
check "Identity validate" "/api/identity/Auth/validate" || FAIL=1
check "Catalog books" "/api/catalog/books" || FAIL=1
check "Circulation transactions" "/api/circulation/transactions?pageSize=5" || FAIL=1

if [[ "$FAIL" -eq 0 ]]; then
  echo "OK — JWT đồng bộ across services"
else
  echo "FAIL — chạy: bash scripts/fix-jwt-sync.sh"
  exit 1
fi
