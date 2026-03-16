using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

// README.md를 읽고 아래에 코드를 작성하세요.

Console.WriteLine("=== 경로 검증 테스트 ===");
FilePathValidator validator = new FilePathValidator();
string[] allowed = { ".txt", ".csv", ".pdf" };
 

Console.WriteLine("=== 경로 검증 테스트 ===");
TestPath(validator, "C:/Users/data/report.txt");
TestPath(validator, null);
TestPath(validator, "C:/Users/data/invalid<char>.txt");
TestPath(validator, new string('a', 261)); // 260자 초과

Console.WriteLine("\n=== 확장자 검증 테스트 ===");
TestExtension(validator, "report.txt", allowed);
TestExtension(validator, "data.csv", allowed);
TestExtension(validator, "virus.exe", allowed);

static void TestPath(FilePathValidator validator, string path)
{
    try
    {
        validator.ValidatePath(path);
    }
    catch (ArgumentNullException)
    {
        Console.WriteLine("[ArgumentNull 오류] 경로는 null이거나 비어있을 수 없습니다.");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"[Argument 오류] {ex.Message}");
    }
}

static void TestExtension(FilePathValidator validator, string path, string[] allowed)
{
    try
    {
        validator.ValidateExtension(path, allowed);
    }
    catch (ArgumentException ex)
    {
        // 예외 메시지에서 파라미터 정보(Parameter 'path')를 제외
        string cleanMessage = ex.Message.Split('\r')[0];//
        Console.WriteLine($"[Argument 오류] {cleanMessage}");
    }
}


public class FilePathValidator
{
    // 금지된 문자 배열
    private static readonly char[] InvalidChars = { '<', '>', '|', '"', '*', '?' };

    public void ValidatePath(string path)
    {
        // Null 또는 빈 문자열 체크
        if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(nameof(path), "경로는 null이거나 비어있을 수 없습니다.");

        // 금지 문자 체크
        foreach (char c in InvalidChars)
        {
            if (path.Contains(c))
                throw new ArgumentException($"경로에 금지 문자 '{c}'가 포함되어 있습니다.", nameof(path));
        }

         //길이 체크
        if (path.Length > 260)
            throw new ArgumentOutOfRangeException(nameof(path), "경로 길이가 260자를 초과합니다.");

        Console.WriteLine($"경로가 유효합니다: {path}");
    }
    // 확장자 검증 메서드
    public void ValidateExtension(string path, string[] allowedExtensions)
    {
        string extension = Path.GetExtension(path);// 확장자 추출
        if (!allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
        // 대소문자 구분 없이 허용된 확장자 목록에 포함되어 있는지 체크
        {
            throw new ArgumentException($"허용되지 않은 확장자입니다: {extension}", nameof(path));
            
        }
        Console.WriteLine($"확장자가 유효합니다: {extension}");

    }
}
