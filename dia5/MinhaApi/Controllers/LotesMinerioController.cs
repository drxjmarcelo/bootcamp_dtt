using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Dtos;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotesMinerioController : ControllerBase
    {
        private readonly AppDbContext _db;

        public LotesMinerioController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lotes = await _db.LotesMinerio.ToListAsync();
            return Ok(lotes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lote = await _db.LotesMinerio.FindAsync(id);
            return lote is null ? NotFound() : Ok(lote);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoteMinerioDto input)
        {
            // Validações básicas
            if (input.TeorFe is < 0 or > 100) return BadRequest("TeorFe inválido.");
            
            var exists = await _db.LotesMinerio.AnyAsync(x => x.CodigoLote == input.CodigoLote);
            if (exists) return Conflict("Código de lote já existe.");

            var lote = new LoteMinerio
            {
                CodigoLote = input.CodigoLote,
                MinaOrigem = input.MinaOrigem,
                TeorFe = input.TeorFe,
                Umidade = input.Umidade,
                SiO2 = input.SiO2,
                P = input.P,
                Toneladas = input.Toneladas,
                // Garante que a data seja UTC para o PostgreSQL
                DataProducao = input.DataProducao.HasValue 
                    ? DateTime.SpecifyKind(input.DataProducao.Value, DateTimeKind.Utc) 
                    : DateTime.UtcNow,
                Status = (StatusLote)input.Status,
                LocalizacaoAtual = input.LocalizacaoAtual
            };

            _db.LotesMinerio.Add(lote);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = lote.Id }, lote);
        }
    }
}