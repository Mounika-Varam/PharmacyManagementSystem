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
    public class PickedUpOrdersController : Controller
    {
        private readonly IPickedUpOrderRepository _repository;
        private readonly IMapper _mapper;
        public PickedUpOrdersController(IPickedUpOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var pickedUpOrders = await _repository.GetAllPickedUpOrdersAsync();
            var pickedUpOrdersDto = _mapper.Map<List<PickedUpOrderDto>>(pickedUpOrders);

            return Ok(pickedUpOrdersDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var pickedUpOrder = await _repository.GetPickedUpOrderByIdAsync(id);

            if (pickedUpOrder == null)
            {
                return NotFound();
            }
            var pickedUpOrderDto = _mapper.Map<PickedUpOrder>(pickedUpOrder);

            return Ok(pickedUpOrderDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromBody] AddPickedUpOrderRequestDto addPickedUpOrderDto)
        {
            var pickedUpOrder = _mapper.Map<PickedUpOrder>(addPickedUpOrderDto);

            pickedUpOrder = await _repository.CreatePickedUpOrderAsync(pickedUpOrder);

            var pickedUpOrderDto = _mapper.Map<PickedUpOrderDto>(pickedUpOrder);

            return Ok(pickedUpOrderDto);
        }

        //[HttpPut]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdatePickedUpOrderRequestDto updatePickedUpOrderRequestDto)
        //{
        //    var pickedUpOrder = _mapper.Map<PickedUpOrder>(updatePickedUpOrderRequestDto);

        //    pickedUpOrder = await _repository.UpdatePickedUpOrderAsync(id, pickedUpOrder);

        //    if (pickedUpOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    var pickedUpOrderDto = _mapper.Map<PickedUpOrderDto>(pickedUpOrder);

        //    return Ok(pickedUpOrderDto);
        //}

        //[HttpDelete]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        //{
        //    var pickedUpOrder = await _repository.DeletePickedUpOrderAsync(id);

        //    if (pickedUpOrder == null)
        //    {
        //        return NotFound();
        //    }

        //    var pickedUpOrderDto = _mapper.Map<PickedUpOrderDto>(pickedUpOrder);

        //    return Ok(pickedUpOrderDto);

        //}
    }
}
