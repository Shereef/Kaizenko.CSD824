namespace Kaizenko.VendingMachine.Controllers
{
    internal class PaymentProcessor
    {
        public PaymentProcessor()
        {
            ResetBalance();
        }

        double Balance { get; set; }
        internal void ProcessPayment(double amount)
        {
            Balance += amount;
        }

        internal void ResetBalance()
        {
            Balance = 0;
        }

        internal void DecreaseBalance(double amount)
        {
            Balance -= amount;
        }

        internal double GetBalance()
        {
            return Balance ;
        }

        internal bool IsPaymentMade(double price)
        {
            return Balance >= price;
        }
    }
}