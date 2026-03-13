using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

// README.md를 읽고 코드를 작성하세요.

Inventory inventory = new Inventory(3);
    Console.WriteLine("=== 인벤토리 테스트 ===");
    inventory.AddItem("검");
    inventory.AddItem("방패");
    inventory.AddItem("포션");
try
{
    inventory.AddItem("도끼"); // 예외 발생
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"[인벤토리 오류] {ex.Message}");
}
Console.WriteLine();
inventory.ShowItems();

inventory.RemoveItem("포션");
Console.WriteLine();
 

try
{
    inventory.RemoveItem("도끼");
}
catch (ItemNotFoundException ex)
{
    Console.WriteLine($"[인벤토리 오류] {ex.Message}");
}
Console.WriteLine();
inventory.ShowItems();

class Inventory
{
    private int maxCapacity {  get; set; }
    private List<string> items = new List<string>();

    public Inventory(int capacity)
    {
        maxCapacity = capacity;
    }
    public void AddItem(string itemName)
    {
        if(maxCapacity <= items.Count)
        {
             throw new InvalidOperationException($"인벤토리가 가득 찼습니다. (아이템: {itemName})");
        }
        
        items.Add(itemName);
        Console.WriteLine($"아이템 '{itemName}' 추가됨");
    }

    public void RemoveItem(string itemName)
    {
        if(!items.Contains(itemName))
        {
            throw new ItemNotFoundException(itemName);
        }
        items.Remove(itemName);
        Console.WriteLine($"아이템 '{itemName}' 제거됨");
    }

    public void ShowItems()
    {
        Console.Write("현재 인벤토리: ");
        foreach(var item in items)
        {
            Console.Write($"{item}, ");
        }
    }

}

class ItemNotFoundException : Exception
{
    public string ItemName { get; }
    public ItemNotFoundException(string itemName) : base($"아이템을 찾을 수 없습니다: {itemName}")
    {
        ItemName = itemName;
    }
}