# C# 연습문제 - FilePathValidator

## 문제

파일 경로를 검증하는 클래스를 구현하세요.

`FilePathValidator` 클래스는 다음 검증 메서드를 제공합니다:

1. `ValidatePath(string path)` - 경로 검증
   - null 또는 빈 문자열이면 `ArgumentNullException` 발생
   - 금지 문자(`<`, `>`, `|`, `"`, `*`, `?`) 포함 시 
	- "경로에 금지 문자 '{문자}'가 포함되어 있습니다." `ArgumentException` 발생
   - 경로 길이가 260자를 초과하면 "경로 길이가 260자를 초과합니다." `ArgumentOutOfRangeException` 발생
   - 유효하면 "경로가 유효합니다: {path}" 출력

2. `ValidateExtension(string path, string[] allowedExtensions)` - 확장자 검증
   - 허용되지 않은 확장자이면 "허용되지 않은 확장자입니다: {extension}" `ArgumentException` 발생
   - 유효하면 "확장자가 유효합니다: {extension}" 출력

## 요구사항

- `ArgumentNullException`, `ArgumentException`, `ArgumentOutOfRangeException`을 상황에 맞게 사용
- Main에서 여러 테스트 케이스를 try-catch로 감싸서 각 예외별 다른 메시지 출력
- nameof 연산자 사용 권장

## 예상 실행 결과

```
=== 경로 검증 테스트 ===
경로가 유효합니다: C:/Users/data/report.txt
[ArgumentNull 오류] 경로는 null이거나 비어있을 수 없습니다.
[Argument 오류] 경로에 금지 문자 '<'가 포함되어 있습니다.
[ArgumentOutOfRange 오류] 경로 길이가 260자를 초과합니다.

=== 확장자 검증 테스트 ===
확장자가 유효합니다: .txt
확장자가 유효합니다: .csv
[Argument 오류] 허용되지 않은 확장자입니다: .exe
```
