namespace Kaizenko.VendingMachine.Controllers
{
    public class PaymentProcessor
    {
        public PaymentProcessor()
        {
            ResetBalance();
        }

        double Balance { get; set; }
        public void ProcessPayment(double amount)
        {
            Balance += amount;
        }

        public void ResetBalance()
        {
            Balance = 0;
        }

        public void DecreaseBalance(double amount)
        {
            Balance -= amount;
        }

        public double GetBalance()
        {
            return Balance ;
        }

        public bool IsPaymentMade(double price)
        {
            return Balance >= price;
        }
    }
}