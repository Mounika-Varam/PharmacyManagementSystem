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
    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;
        public SuppliersController(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAllAsync()
        {
            var suppliers = await _repository.GetAllSuppliersAsync();
            var suppliersDto = _mapper.Map<List<SupplierDto>>(suppliers);

            return Ok(suppliersDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var supplier = await _repository.GetSupplierByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }
            var supplierDto = _mapper.Map<SupplierDto>(supplier);

            return Ok(supplierDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromBody] AddSupplierRequestDto addSupplierRequestDto)
        {
            var supplier = _mapper.Map<Supplier>(addSupplierRequestDto);

            supplier = await _repository.CreateSupplierAsync(supplier);

            var supplierDto = _mapper.Map<SupplierDto>(supplier);

            return Ok(supplierDto);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateSupplierRequestDto updateSupplierRequestDto)
        {
            var supplier = _mapper.Map<Supplier>(updateSupplierRequestDto);

            supplier = await _repository.UpdateSupplierAsync(id, supplier);

            if (supplier == null)
            {
                return NotFound();
            }

            var supplierDto = _mapper.Map<SupplierDto>(supplier);

            return Ok(supplierDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var supplier = await _repository.DeleteSupplierAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            var supplierDto = _mapper.Map<SupplierDto>(supplier);

            return Ok(supplierDto);

        }
    }
}
