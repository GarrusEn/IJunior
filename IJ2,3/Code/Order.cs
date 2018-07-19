class Order
{
    public Good Good;
    public int Count;

    public int GetTotalPrice()
    {
        if (Good == null)
        {            
            return 0;
        }
        return Good.Price * Count;
    }
    
    public void CompleteTheOrder()
    {
        Good.Count -= Count;
    }
}
