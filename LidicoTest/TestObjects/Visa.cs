namespace LidicoTest.TestObjects
{
    public class Visa : IDebitCard
    {
        public string Charge(double amount)
        {
            return $"Visa card charged with {amount}.";
        }

        public string Return(double amount)
        {
            return $"Visa card refunded with {amount}.";
        }
    }
}