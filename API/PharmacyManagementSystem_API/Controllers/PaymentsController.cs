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
    public class PaymentsController : Controller
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;
        public PaymentsController(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //[HttpGet]
        //[Authorize(Roles = "Admin,Doctor")]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    var payments = await _repository.GetAllPaymentsAsync();
        //    var paymentsDto = _mapper.Map<List<DrugDto>>(payments);

        //    return Ok(paymentsDto);
        //}

        //[HttpGet]
        //[Route("{id:Guid}")]
        //[Authorize(Roles = "Admin,Doctor")]
        //public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        //{
        //    var payment = await _repository.GetPaymentByIdAsync(id);

        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }
        //    var paymentDto = _mapper.Map<PaymentDto>(payment);

        //    return Ok(paymentDto);
        //}

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> CreateAsync([FromBody] AddPaymentRequestDto addPaymentRequestDto)
        {
            var payment = _mapper.Map<Payment>(addPaymentRequestDto);

            payment = await _repository.CreatePaymentAsync(payment);

            var paymentDto = _mapper.Map<PaymentDto>(payment);

            return Ok(paymentDto);
        }

        //[HttpPut]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdatePaymentRequestDto updatePaymentRequestDto)
        //{
        //    var payment = _mapper.Map<Payment>(updatePaymentRequestDto);

        //    payment = await _repository.UpdatePaymentAsync(id, payment);

        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    var paymentDto = _mapper.Map<DrugDto>(payment);

        //    return Ok(paymentDto);
        //}

        //[HttpDelete]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        //{
        //    var payment = await _repository.DeletePaymentAsync(id);

        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    var paymentDto = _mapper.Map<PaymentDto>(payment);

        //    return Ok(paymentDto);

        //}
    }
}
