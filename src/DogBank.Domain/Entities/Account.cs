namespace DogBank.Domain.Entities
{
    public class Account
    {
        public Account(Person person, string number, double balance)
        {
            Person = person;
            Number = number;
            Balance = balance;
        }

        public Person Person { get; private set; }
        public string Number { get; private set; }
        public double Balance { get; private set; }

        public double CreditValue(double value)
        {
            Balance += value;
            return Balance;
        }

        public double DebitValue(double value)
        {
            Balance -= value;
            return Balance;
        }
    }
}
