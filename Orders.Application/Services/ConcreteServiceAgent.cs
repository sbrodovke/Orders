using System;

namespace Orders.Application.Services
{
    public class ConcreteServiceAgent<TConcreteService> : IServiceAgent
    {
        private readonly TConcreteService _service;
        private readonly Type _serviceType = typeof(TConcreteService);

        public ConcreteServiceAgent(TConcreteService service)
            => _service = service;

        public bool IsSuitable<TService>()
            => typeof(TService) == _serviceType;

        public TConcreteService GetService()
            => _service;
    }
}