namespace DogBank.Domain.Entities
{
    public class Person
    {
        public Person(Guid id, string name, string document)
        {
            Id = id;
            Name = name;
            Document = document;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
