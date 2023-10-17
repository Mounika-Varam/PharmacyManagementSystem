using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.API.Mappings;
using PharmacyManagementSystem.API.Models.DTO;
using PharmacyManagementSystem.API.Models.Domain;
using PharmacyManagementSystem.API.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace PharmacyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class DrugsController : Controller
    {
        private readonly IDrugRepository _repository;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public DrugsController(IDrugRepository repository, IMapper mapper, IImageRepository imageRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAllAsync() 
        {
            var drugs = await _repository.GetAllDrugsAsync();
            var drugsDto = _mapper.Map<List<DrugDto>>(drugs);

            return Ok(drugsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,Doctor")]

        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var drug = await _repository.GetDrugByIdAsync(id);

            if (drug == null)
            {
                return NotFound();
            }
            var drugDto = _mapper.Map<DrugDto>(drug);

            return Ok(drugDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> CreateAsync([FromBody] AddDrugRequestDto addDrugRequestDto)
        {
            var drug = _mapper.Map<Drug>(addDrugRequestDto);

            drug = await _repository.CreateDrugAsync(drug);

            var drugDto = _mapper.Map<DrugDto>(drug);

            return Ok(drugDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin,Doctor")]

        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateDrugRequestDto updateDrugRequestDto)
        {
            var drug = _mapper.Map<Drug>(updateDrugRequestDto);

            drug = await _repository.UpdateDrugAsync(id, drug);

            if(drug == null)
            {
                return NotFound();
            }

            var drugDto = _mapper.Map<DrugDto>(drug);

            return Ok(drugDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var drug = await _repository.DeleteDrugAsync(id);

            if(drug == null)
            {
                return NotFound();
            }

            var drugDto = _mapper.Map<DrugDto>(drug);

            return Ok(drugDto);

        }

        [HttpPost]
        [Route("{id:Guid}/upload-image")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid id, IFormFile drugImage)
        {
            if(await _repository.ExistsAsync(id))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(drugImage.FileName);
                var imagePath = await _imageRepository.Upload(drugImage, fileName);

                if(await _repository.UpdateDrugImageAsync(id, imagePath))
                {
                    return Ok(imagePath);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("expired")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetExpiredDrugsAsync()
        {
            var drugs = await _repository.GetExpiredDrugs();
            var drugsDto = _mapper.Map<List<DrugDto>>(drugs);

            return Ok(drugsDto);
        }

        [HttpGet]
        [Route("out-of-stock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOutOfStockDrugs()
        {
            var drugs = await _repository.GetOutOfStockDrugs();
            var drugsDto = _mapper.Map<List<DrugDto>>(drugs);

            return Ok(drugsDto);
        }


    }
}
