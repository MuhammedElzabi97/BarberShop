using Microsoft.AspNetCore.Mvc;
using WebProjesi.Data.Services;
using WebProjesi.Models;

namespace WebProjesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HizmetApiController : ControllerBase
    {
        private readonly IHizmetServices _hizmetService;

        public HizmetApiController(IHizmetServices hizmetService)
        {
            _hizmetService = hizmetService;
        }

        // GET: api/HizmetApi
        [HttpGet]
        public IActionResult GetAll()
        {
            var hizmetler = _hizmetService.GetAll();
            return Ok(hizmetler);
        }

        // GET: api/HizmetApi/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hizmet = _hizmetService.GetById(id);
            if (hizmet == null)
            {
                return NotFound();
            }
            return Ok(hizmet);
        }

        // POST: api/HizmetApi
        [HttpPost]
        public IActionResult Create([FromBody] Hizmet hizmet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _hizmetService.YeniHizmetEkle(hizmet);
            return CreatedAtAction(nameof(GetById), new { id = hizmet.HizmetID }, hizmet);
        }

        // PUT: api/HizmetApi/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Hizmet guncelHizmet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mevcutHizmet = _hizmetService.GetById(id);
            if (mevcutHizmet == null)
            {
                return NotFound();
            }

            _hizmetService.HizmetGuncelle(id, guncelHizmet);
            return NoContent();
        }

        // DELETE: api/HizmetApi/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mevcutHizmet = _hizmetService.GetById(id);
            if (mevcutHizmet == null)
            {
                return NotFound();
            }

            _hizmetService.HizmetSil(id);
            return NoContent();
        }
    }
}
