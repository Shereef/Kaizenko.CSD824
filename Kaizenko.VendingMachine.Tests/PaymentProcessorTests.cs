using Kaizenko.VendingMachine.Controllers;

namespace Kaizenko.VendingMachine.Tests
{
    [TestFixture]
    public class PaymentProcessorTests
    {
        PaymentProcessor paymentProcessor;

        public PaymentProcessorTests()
        {
            paymentProcessor = new();
        }

        [SetUp]
        public void Setup()
        {
            // Common arrange aka Given
            paymentProcessor = new();
        }

        [Test]
        public void ProcessPaymentGetBalance_WhenNoMoneyAdded_Expect0cBalance()
        {
            // Arrange aka Given
            // Act aka When
            paymentProcessor.ProcessPayment(0);
            // Assert aka Then
            var balance = paymentProcessor.GetBalance();
            Assert.That(balance, Is.EqualTo(0));
        }

        [Test]
        public void ProcessPaymentGetBalance_When25cAdded_Expect25cBalance()
        {
            // Arrange aka Given
            // Act aka When
            paymentProcessor.ProcessPayment(0.25);
            // Assert aka Then
            var balance = paymentProcessor.GetBalance();
            Assert.That(balance, Is.EqualTo(0.25));
        }

        [Test]
        public void IsPaymentMade_WhenNoMoney_ExpectFalse()
        {
            // Arrange aka Given
            // Act aka When
            var product = paymentProcessor.IsPaymentMade(0.5);
            // Assert aka Then
            Assert.That(product, Is.False);
        }

        [Test]
        public void IsPaymentMade_When25cAdded_ExpectFalse()
        {
            // Arrange aka Given
            paymentProcessor.ProcessPayment(0.25);
            // Act aka When
            var product = paymentProcessor.IsPaymentMade(0.5);
            // Assert aka Then
            Assert.That(product, Is.False);
        }

        [Test]
        public void IsPaymentMade_When50cAdded_ExpectTrue()
        {
            // Arrange aka Given
            paymentProcessor.ProcessPayment(0.5);
            // Act aka When
            var product = paymentProcessor.IsPaymentMade(0.5);
            // Assert aka Then
            Assert.That(product, Is.True);
        }

        [Test]
        public void IsPaymentMade_When75cAdded_ExpectTrue()
        {
            // Arrange aka Given
            paymentProcessor.ProcessPayment(0.75);
            // Act aka When
            var product = paymentProcessor.IsPaymentMade(0.5);
            // Assert aka Then
            Assert.That(product, Is.True);
        }

        [Test]
        public void DecreaseBalance_When75cAddedAnd50cDecreased_Expect25cBalance()
        {
            // Arrange aka Given
            paymentProcessor.ProcessPayment(0.75);
            // Act aka When
            paymentProcessor.DecreaseBalance(0.5);
            // Assert aka Then
            var balance = paymentProcessor.GetBalance();
            Assert.That(balance, Is.EqualTo(0.25));
        }

        [Test]
        public void DecreaseBalance_When50cAddedAnd50cDecreased_Expect0cBalance()
        {
            // Arrange aka Given
            paymentProcessor.ProcessPayment(0.5);
            // Act aka When
            paymentProcessor.DecreaseBalance(0.5);
            // Assert aka Then
            var balance = paymentProcessor.GetBalance();
            Assert.That(balance, Is.EqualTo(0));
        }

        [Test]
        public void ResetBalance_WhenResetBalanceWith25cAdded_Expect0cBalance()
        {
            // Arrange aka Given
            paymentProcessor.ProcessPayment(0.25);
            // Act aka When
            paymentProcessor.ResetBalance();
            // Assert aka Then
            var balance = paymentProcessor.GetBalance();
            Assert.That(balance, Is.EqualTo(0));
        }
    }
}