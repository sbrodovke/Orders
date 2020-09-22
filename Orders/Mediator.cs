using System;
using System.Collections.Generic;
using System.Linq;
using Orders.Application.Handlers;
using Orders.Application.Services;

namespace Orders
{
    public class Mediator : IMediator
    {
        private readonly IEnumerable<IServiceAgent> _serviceAgents;

        public Mediator(IEnumerable<IServiceAgent> serviceAgents)
            => _serviceAgents = serviceAgents;

        public TResponse SendRequest<TRequest, TResponse>(TRequest request)
        {
            var serviceAgent = _serviceAgents.First(_ => _.IsSuitable<IRequestHandler<TRequest, TResponse>>());

            if (serviceAgent is ConcreteServiceAgent<IRequestHandler<TRequest, TResponse>> concreteServiceAgent)
                return concreteServiceAgent.GetService().Handle(request);

            throw new Exception();
        }
    }
}