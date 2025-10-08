using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinylVault.Api.Data;
using VinylVault.Shared.DTOs;
using VinylVault.Shared.Models;

namespace VinylVault.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public RecordsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/records
        [HttpGet, Authorize]
        public async Task<IActionResult> GetAll()
        {
            var records = await _dataContext.Records.ToListAsync();

            var recordDtos = records.Select(r => new RecordReadDto
            {
                Id = r.Id,
                Artist = r.Artist,
                Album = r.Album,
                Year = r.Year
            }).ToList();

            return Ok(recordDtos);
        }

        // GET api/records/5
        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var records = await _dataContext.Records.FindAsync(id);

            //var record = records.FirstOrDefault(x => x.Id == id);
            if (records == null)
                return NotFound();

            var dto = new RecordReadDto
            {
                Id = records.Id,
                Artist = records.Artist,
                Album = records.Album,
                Year = records.Year
            };

            return Ok(dto);
        }

        // POST api/records
        [HttpPost, Authorize]
        public async Task<IActionResult> Create(RecordCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newRecord = new Record
            {
                Artist = dto.Artist,
                Album = dto.Album,
                Year = dto.Year
            };

            _dataContext.Records.Add(newRecord);
            await _dataContext.SaveChangesAsync();

            var readDto = new RecordReadDto
            {
                Id = newRecord.Id,
                Artist = newRecord.Artist,
                Album = newRecord.Album,
                Year = newRecord.Year
            };

            return CreatedAtAction(nameof(GetById), new { id = newRecord.Id }, readDto);

        }
    }
}
