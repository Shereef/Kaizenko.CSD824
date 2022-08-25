using Kaizenko.VendingMachine.Models;

namespace Kaizenko.VendingMachine.Controllers
{
    public class VendingMachineController
    {
        IPaymentProcessor paymentProcessor ;
        public VendingMachineController(IPaymentProcessor paymentProcessor )
        {
            this.paymentProcessor = paymentProcessor;
        }

        public double ReleaseChange()
        {
            double change = paymentProcessor.GetBalance();
            paymentProcessor.ResetBalance();
            return change;
        }

        public void InsertQuarter()
        {
            paymentProcessor.ProcessPayment(0.25);
        }

        public Product? BuyProduct()
        {
            if (paymentProcessor.IsPaymentMade(0.5))
            {
                paymentProcessor.DecreaseBalance(0.5);
                return new Product();
            }
            return null;
        }
    }
}