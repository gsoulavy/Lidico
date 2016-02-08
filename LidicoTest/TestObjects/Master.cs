namespace LidicoTest.TestObjects
{
    public class Master : IDebitCard
    {
        public string Charge(double amount)
        {
            return $"MasterCard charged with {amount}.";
        }

        public string Return(double amount)
        {
            return $"MasterCard refunded with {amount}.";
        }
    }
}