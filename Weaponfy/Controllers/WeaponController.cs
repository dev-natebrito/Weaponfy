using Microsoft.AspNetCore.Mvc;
using Weaponfy.Models;
using Weaponfy.Services;

namespace Weaponfy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        // GET: api/Weapon
        [HttpGet]
        public ActionResult<List<Weapon>> Get()
        {
            return _weaponService.Get();
        }

        // GET: api/Weapon/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Weapon> Get(string id)
        {
            var weapon = _weaponService.Get(id);
            if (weapon == null) return NotFound($"Weapon with id {id} not found");
            return weapon;
        }

        // POST: api/Weapon
        [HttpPost]
        public ActionResult<Weapon> Post([FromBody] Weapon weapon)
        {
            _weaponService.Create(weapon);
            return CreatedAtAction(nameof(Get), new {id = weapon.Id}, weapon);
        }

        // PUT: api/Weapon/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Weapon weapon)
        {
            var existingWeapon = _weaponService.Get(id);

            if (existingWeapon == null)
            {
                return NotFound($"Weapon with id {id} not found");
            }

            _weaponService.Update(id, weapon);
            return NoContent();
        }

        // DELETE: api/Weapon/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            
            var weapon = _weaponService.Get(id);
            if (weapon == null)
            {
                return NotFound($"Weapon with id {id} not found");
            }

            _weaponService.Remove(id);
            return Ok($"Weapon with id: {id} deleted ");
        }
    }
}