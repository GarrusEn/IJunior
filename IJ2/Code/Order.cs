class Order
{
    public Good Good;
    public int Count;

    public int GetTotalPrice()
    {
        if (Good == null)
        {
            System.Console.WriteLine("Товар не подвезли");
            return 0;
        }
        return Good.Price * Count;
    }
    
    public void CompleteTheOrder()
    {
        Good.Count -= Count;
    }
}
