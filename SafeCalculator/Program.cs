using System;

// README.md를 읽고 코드를 작성하세요.
SafeCalculator calculator = new SafeCalculator();

Console.WriteLine("=== 테스트 1: 정상 입력 ===");
calculator.Divide("10", "2");

Console.WriteLine("\n=== 테스트 2: 0으로 나누기 ===");
calculator.Divide("10", "0");

Console.WriteLine("\n=== 테스트 3: 잘못된 형식 ===");
calculator.Divide("abc", "2");


class SafeCalculator
{
    public void Divide(string num1, string num2)
    {
        try
        {
            // 1. 문자열 -> 숮자 
            int n1 = int.Parse(num1);
            int n2 = int.Parse(num2);

            
            int result = n1 / n2;

            //정상 결과
            Console.WriteLine($"{n1} / {n2} = {result}");
        }
        catch (FormatException)
        {
            // 숫자가 아닌 값
            Console.WriteLine("올바른 숫자를 입력하세요.");
        }
        catch (DivideByZeroException)
        {
            // 0으로 나눌떄
            Console.WriteLine("0으로 나눌 수 없습니다.");
        }
        finally
        {
             
            Console.WriteLine("계산기를 종료합니다.");
        }
    }
}