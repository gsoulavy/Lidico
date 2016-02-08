namespace LidicoTest.TestObjects
{
    public interface IDebitCard
    {
        string Charge(double amount);

        string Return(double amount);
    }
}