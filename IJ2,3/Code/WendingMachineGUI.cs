using System;

class WendingMachineGUI
{
    public WendingMachine Machine;

    public void Update()
    {
        Console.Clear();
        Console.WriteLine($"Balance - {Machine.Balance}");
        Console.WriteLine();

        Console.WriteLine("Write command...");

        string command = Console.ReadLine();
        switch (command)
        {
            case "help":
                Console.WriteLine("list\norder\ntakemymoney\ngetmymoney\n");
                break;
            case "list":
                foreach (Good good in Machine.GetProductList())
                {
                    Console.WriteLine($">{good.Name} [{good.Count}]");
                }
                break;
            case "takemymoney":
                Console.WriteLine("Положите денежку");
                int coin = Convert.ToInt32(Console.ReadLine());
                Machine.AddBalance(coin);
                break;
            case "getmymoney":
                Console.WriteLine("Заберите сдачу");
                Machine.ClearBalance();
                break;
            case "order":
                Console.WriteLine("имя");
                string name = Console.ReadLine();
                Console.WriteLine("кол-во");
                int count = Convert.ToInt32(Console.ReadLine());

                Order order = new Order();
                order.Good = Machine.GetProduct(name);
                order.Count = count;

                Console.WriteLine($"Общая сума - {order.GetTotalPrice()}");

                Machine.ApplyOrder(order);
                break;
            default:
                break;
        }
        Console.ReadKey();
    }
}
