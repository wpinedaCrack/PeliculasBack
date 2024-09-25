using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace API.Controllers
{
    public class PersonaController : BaseApiController
    {
        public readonly AplicationDbContext _db;

        public PersonaController(AplicationDbContext db)
        {
            _db = db;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            var personas = await _db.Personas.ToListAsync();
            return Ok(personas);
        }

        [HttpGet("{numIdentificacion}")]
        public async Task<ActionResult<Persona>> GetPersona(string numIdentificacion)
        {
            var persona = await _db.Personas.Where(x => x.NumeroIdentificacion.Equals(numIdentificacion)).FirstOrDefaultAsync();
            return Ok(persona);
        }


        [HttpPost]
        public async Task<ActionResult<Persona>> Guardar(Persona persona)
        {
            persona.Id = Guid.NewGuid();
            _db.Personas.Add(persona);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonas), new { id = persona.Id }, persona);
        }

        // Método para modificar una persona existente (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(Guid id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest("El ID no coincide");
            }

            _db.Entry(persona).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private bool Exists(Guid id)
        {
            return _db.Personas.Any(e => e.Id == id);
        }
    }
}
