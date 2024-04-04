using MediatR;

namespace Contract
{
    public class ProductCreatedEvent(int id,int stoc) : INotification 
    {
        public int Id { get; } = id;
        public int Sock { get; } = stoc;
    }

}
