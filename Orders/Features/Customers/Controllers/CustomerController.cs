using System;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Features.Customers.Handlers;
using Orders.Domain.Customers;
using Orders.Features.Customers.Requests;
using Orders.Features.Customers.Responses;

namespace Orders.Features.Customers.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        public IActionResult Get([FromQuery(Name = "uid")] string customerUid)
        {
            try
            {
                var request = new GetCustomerRequest(customerUid);
                var customer = _mediator.SendRequest<IGetCustomerRequest, ICustomerDto>(request);
                return Ok(new CustomerResponse(customer));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        public IActionResult Create([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            try
            {
                var customer = _mediator.SendRequest<ICreateCustomerRequest, ICustomerDto>(createCustomerRequest);
                return Ok(new CustomerResponse(customer));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}