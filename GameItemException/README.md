c# 게임 인벤토리 사용자 정의 예외

게임 인벤토리 시스템을 위한 사용자 정의 예외를 구현하세요.

### 예외 클래스

1. `InventoryFullException` - 인벤토리가 가득 찼을 때 발생
   - 현재 용량(`Capacity`)과 아이템 이름(`ItemName`) 속성 포함

2. `ItemNotFoundException` - 아이템을 찾을 수 없을 때 발생
   - 아이템 이름(`ItemName`) 속성 포함

### Inventory 클래스

- `maxCapacity` 필드로 최대 용량 설정 (생성자에서 지정)
- `items` 리스트로 아이템 관리
- `AddItem(string itemName)` - 아이템 추가
  - 용량 초과 시 `InventoryFullException` 발생
- `RemoveItem(string itemName)` - 아이템 제거
  - 아이템 없으면 `ItemNotFoundException` 발생
- `ShowItems()` - 현재 아이템 목록 출력

## 예상 실행 결과

```
=== 인벤토리 테스트 ===
아이템 '검' 추가됨
아이템 '방패' 추가됨
아이템 '포션' 추가됨
[인벤토리 오류] 인벤토리가 가득 찼습니다. (용량: 3, 아이템: 활)

현재 인벤토리: 검, 방패, 포션
아이템 '포션' 제거됨
[인벤토리 오류] 아이템을 찾을 수 없습니다: 도끼

현재 인벤토리: 검, 방패
```
