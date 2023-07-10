namespace DogBank.Infra
{
    public interface IMessageBus
    {
        Task<IEnumerable<T>> GetMessages<T>();
        Task SendMessage<T>(T message);
    }
}
