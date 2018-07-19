using System;

class WendingMachine
{
    public int Balance;
    public GoodsRepository Goods;

    public void AddBalance(int coin)
    {
        Balance += coin;
    }

    public int ClearBalance()
    {
        int oldBalance = Balance;
        Balance = 0;
        return oldBalance;
    }

    public void ApplyOrder(Order order)
    {
        if (order == null) throw new ArgumentNullException("order", "");
        if (Balance < order.GetTotalPrice()) throw new InvalidOperationException("");

        Balance -= order.GetTotalPrice();
        order.CompleteTheOrder();
    }

    public Good[] GetProductList()
    {
        return Goods.GetAvialableGoods();
    }

    public Good GetProduct(string name)
    {
        return Goods.GetProduct(name);
    }
}
