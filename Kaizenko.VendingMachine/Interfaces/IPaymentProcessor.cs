    public interface IPaymentProcessor
    {
        void DecreaseBalance(double amount);
        double GetBalance();
        bool IsPaymentMade(double price);
        void ProcessPayment(double amount);
        void ResetBalance();
    }