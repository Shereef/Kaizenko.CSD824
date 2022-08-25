using Kaizenko.VendingMachine.Models;

namespace Kaizenko.VendingMachine.Controllers
{
    public class VendingMachineController
    {
        public VendingMachineController()
        {
            QuarterCount = 0;
        }

        int QuarterCount { get; set; }
        public double ReleaseChange()
        {
            double change = QuarterCount * 0.25;
            QuarterCount = 0;
            return change;
        }

        public void AddMoney()
        {
            QuarterCount++;
        }

        public Product? BuyProduct()
        {
            if (QuarterCount >= 2)
            {
                QuarterCount -= 2;
                return new Product();
            }
            return null;
        }
    }
}