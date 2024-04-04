using MediatR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class AddProductCommandHandler(IMediator mediator) : IRequestHandler<AddProductCommand>
    {
        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        
        =>    await mediator.Publish(new ProductCreatedEvent(0,3), cancellationToken);
        
    }
}
