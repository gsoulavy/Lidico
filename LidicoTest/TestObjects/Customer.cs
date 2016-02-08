namespace LidicoTest.TestObjects
{
    public class Customer
    {
        private readonly IDebitCard _debitCard;

        public Customer(IDebitCard debitCard)
        {
            this._debitCard = debitCard;
        }

        public string Charge(double amount)
        {
            return _debitCard.Charge(amount);
        }

        public string Refund(double amount)
        {
            return _debitCard.Return(amount);
        }
    }
}