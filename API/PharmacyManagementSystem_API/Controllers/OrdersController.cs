using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.API.Models.Domain;
using PharmacyManagementSystem.API.Models.DTO;
using PharmacyManagementSystem.API.Repositories;
using System.Data;

namespace PharmacyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _repository.GetAllOrdersAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return Ok(ordersDto);
        }

        [HttpGet]
        [Route("doctor-orders")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPendingAsync()
        {
            var orders = await _repository.GetPendingOrdersAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return Ok(ordersDto);
        }

        [HttpGet]
        [Route("picked-orders")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPickedUpOrders()
        {
            var orders = await _repository.GetAllPickedUpOrdersAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return Ok(ordersDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var order = await _repository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> CreateAsync([FromBody] AddOrderRequestDto addOrderRequestDto)
        {
            var order = _mapper.Map<Order>(addOrderRequestDto);

            order = await _repository.CreateOrderAsync(order);

            var orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOrderRequestDto updateOrderRequestDto)
        {
            var order = _mapper.Map<Order>(updateOrderRequestDto);

            order = await _repository.UpdateOrderAsync(id, order);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }

        //[HttpDelete]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        //{
        //    var order = await _repository.DeleteOrderAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderDto = _mapper.Map<OrderDto>(order);

        //    return Ok(orderDto);

        //}

    }
}
