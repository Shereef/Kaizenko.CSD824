using Kaizenko.VendingMachine.Controllers;

namespace Kaizenko.VendingMachine.Tests
{
    [TestFixture]
    public class VendingMachineControllerTests
    {
        VendingMachineController vendingMachineController;
        [SetUp]
        public void Setup()
        {
            // Common arrange aka Given
            vendingMachineController = new();
        }

        [Test]
        public void ReleaseChange_WhenNoMoneyAdded_Expect0cChange()
        {
            // Arrange aka Given
            // Act aka When
            var change = vendingMachineController.ReleaseChange();
            // Assert aka Then
            Assert.That(change, Is.EqualTo(0));
        }

        [Test]
        public void ReleaseChange_When25cAdded_Expect25cChange()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            // Act aka When
            var change = vendingMachineController.ReleaseChange();
            // Assert aka Then
            Assert.That(change, Is.EqualTo(0.25));
        }

        [Test]
        public void ReleaseChange_When50cAdded_Expect50cChange()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            // Act aka When
            var change = vendingMachineController.ReleaseChange();
            // Assert aka Then
            Assert.That(change, Is.EqualTo(0.50));
        }

        [Test]
        public void BuyProduct_WhenNoMoney_ExpectNoProduct()
        {
            // Arrange aka Given
            // Act aka When
            var product = vendingMachineController.BuyProduct();
            // Assert aka Then
            Assert.That(product, Is.Null);
        }

        [Test]
        public void BuyProduct_When25cAdded_ExpectNoProduct()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            // Act aka When
            var product = vendingMachineController.BuyProduct();
            // Assert aka Then
            Assert.That(product, Is.Null);
        }

        [Test]
        public void BuyProduct_When50cAdded_ExpectProduct()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            // Act aka When
            var product = vendingMachineController.BuyProduct();
            // Assert aka Then
            Assert.That(product, Is.Not.Null);
        }

        [Test]
        public void BuyProduct_When75cAdded_ExpectProduct()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            // Act aka When
            var product = vendingMachineController.BuyProduct();
            // Assert aka Then
            Assert.That(product, Is.Not.Null);
        }

        [Test]
        public void ReleaseChange_WhenProductPurchasedWith75cAdded_Expect25cChange()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            vendingMachineController.BuyProduct();
            // Act aka When
            var change = vendingMachineController.ReleaseChange();
            // Assert aka Then
            Assert.That(change, Is.EqualTo(0.25));
        }

        [Test]
        public void ReleaseChange_WhenProductPurchasedWit50cAdded_Expect0cChange()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            vendingMachineController.BuyProduct();
            // Act aka When
            var change = vendingMachineController.ReleaseChange();
            // Assert aka Then
            Assert.That(change, Is.EqualTo(0));
        }

        [Test]
        public void ReleaseChange_WhenChangeReleasedTwiceWith25cAdded_Expect0cChange()
        {
            // Arrange aka Given
            vendingMachineController.AddMoney();
            vendingMachineController.AddMoney();
            vendingMachineController.ReleaseChange();
            // Act aka When
            var change = vendingMachineController.ReleaseChange();
            // Assert aka Then
            Assert.That(change, Is.EqualTo(0));
        }
    }
}