using System;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Features.Orders.Handlers;
using Orders.Domain.Orders;
using Orders.Features.Orders.Requests;
using Orders.Features.Orders.Responses;

namespace Orders.Features.Orders.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        public IActionResult Get([FromQuery(Name = "uid")] string orderUid)
        {
            try
            {
                var request = new GetOrderRequest(orderUid);
                var order = _mediator.SendRequest<IGetOrderRequest, IOrderDto>(request);
                return Ok(new OrderResponse(order));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        public IActionResult Create([FromBody] CreateOrderRequest createOrderRequest)
        {
            try
            {
                var order = _mediator.SendRequest<ICreateOrderRequest, IOrderDto>(createOrderRequest);
                return Ok(new OrderResponse(order));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        public IActionResult AddProductInOrder([FromBody] AddProductInOrderRequest addProductInOrderRequest)
        {
            try
            {
                var order = _mediator.SendRequest<IAddProductInOrderRequest, IOrderDto>(addProductInOrderRequest);
                return Ok(new OrderResponse(order));
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}