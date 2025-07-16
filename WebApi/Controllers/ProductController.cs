using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models.Entities;
using Services;
using Services.Mapper;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repo;
        private readonly IVersionedService<ProductDto, Product> _service;

        public ProductController(IRepository<Product> repo, IVersionedService<ProductDto, Product> service)
        {
            _service = service;
            _repo = repo;
            _repo.ItemAdded += p =>
            {
                var dto = JsonEntityMapper.ToDto<ProductDto>(p);
                Console.WriteLine($"[EVENT] Added: {dto.Title} @ ₹{dto.Price} | JSON={p.JsonDoc}");
            };
        }


        [HttpPost("save")]
        public async Task<IActionResult> Save(ProductDto dto)
        {
            var saved = await _service.SaveAsync(dto);
            return Ok(saved);
        }

        [HttpPost("discard-draft")]
        public async Task<IActionResult> DiscardDraft(ProductDto dto)
        {
            var restored = await _service.DiscardDraftAsync(dto);
            return restored == null ? Ok(restored) : Ok(restored);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }
    }
}
