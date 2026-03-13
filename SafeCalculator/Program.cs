using System;

// README.md를 읽고 코드를 작성하세요.

try
{
    SafeCalculator calculator = new SafeCalculator();
    Console.WriteLine("=== 테스트 1: 정상 입력 ===");
    string input1 = Console.ReadLine();
    string input2 = Console.ReadLine();
    calculator.Divide(input1, input2);
    Console.WriteLine($"{calculator.Number1} / {calculator.Number2} = {calculator.Number1 / calculator.Number2}");

}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"[계산 오류] {ex.Message}");
}
catch (FormatException ex)
{
    Console.WriteLine($"[입력 오류] {ex.Message}");
}
class SafeCalculator
{
    public int Number1 { get; private set; }
    public int Number2 { get; private set; }
    
    
    public void Divide(string num1, string num2)
    {
        if (int.TryParse(num1, out int number1) && int.TryParse(num2, out int number2))
        {
            Number1 = number1;
            Number2 = number2;
        }
        else
        {
            throw new FormatException("입력값이 유효한 정수가 아닙니다.");
        }
    }



}