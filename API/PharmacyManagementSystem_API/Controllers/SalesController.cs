using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PharmacyManagementSystem.API.Models.DTO;
using PharmacyManagementSystem.API.Repositories;
using System.Data;

namespace PharmacyManagementSystem.API.Controllers
{
    public class SalesController : Controller
    {


        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public SalesController(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await _repository.GetAllOrdersAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(sales);

            return Ok(ordersDto);
        }

        [HttpGet]
        [Route("sales-per-month")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetSalesByMonth()
        {
            var sales = await _repository.GetAllOrdersAsync();
            var monthlySales = sales.GroupBy(o => o.OrderDate.Month).Select(ms => new { Month = ms.Key, Sales = ms.Count() });
            return Ok(monthlySales);
        }

        [HttpGet]
        [Route("sales-per-year")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetSaleByYear()
        {
            var sales = await _repository.GetAllOrdersAsync();
            var yearlySales = sales.GroupBy(o => o.OrderDate.Year).Select(ms => new { Year = ms.Key, Sales = ms.Count() });
            return Ok(yearlySales);
        }

        [HttpGet]
        [Route("sales-per-day")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetSaleByDay()
        {
            var sales = await _repository.GetAllOrdersAsync();
            var dailySales = sales.GroupBy(o => o.OrderDate.Day).Select(ms => new { Day = ms.Key, Sales = ms.Count() });
            return Ok(dailySales);
        }

        [HttpGet]
        [Route("sales-per-drug")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSaleByDrug()
        {
            var sales = await _repository.GetAllOrdersAsync();
            var yearlySales = sales.GroupBy(o => o.Drug.DrugName).Select(ms => new { DrugName = ms.Key, Sales = ms.Count() });
            return Ok(yearlySales);
        }
    }
}
