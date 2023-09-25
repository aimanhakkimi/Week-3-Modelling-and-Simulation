class Staff
{
    double amount = 0;

    public void ReceivePayment (int num)
    {
        amount = amount + num * .1;
    }

    public double GetTotalProfit()
    {
        return amount;
    }

}