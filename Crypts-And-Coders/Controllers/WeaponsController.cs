﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crypts_And_Coders.Data;
using Crypts_And_Coders.Models;
using Crypts_And_Coders.Models.Interfaces;

namespace Crypts_And_Coders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly IWeapon _weapon;

        public WeaponsController(IWeapon weapon)
        {
            _weapon = weapon;
        }

        // GET: api/Weapons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapon>>> GetWeapons()
        {
            return await _weapon.GetWeapons();
        }

        // GET: api/Weapons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon>> GetWeapon(int id)
        {
            var weapon = await _weapon.GetWeapon(id);

            if (weapon == null)
            {
                return NotFound();
            }

            return weapon;
        }


        // PUT: api/Weapons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon(int id, Weapon weapon)
        {
            if (id != weapon.Id)
            {
                return BadRequest();
            }
            var result = await _weapon.Update(weapon);

            return Ok(result);
        }

        // POST: api/Weapons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Weapon>> PostWeapon(Weapon weapon)
        {
            await _weapon.Create(weapon);


            return CreatedAtAction("GetWeapon", new { id = weapon.Id }, weapon);
        }

        // DELETE: api/Weapons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Weapon>> DeleteWeapon(int id)
        {
            await _weapon.Delete(id);
            return NoContent();
        }
    }
}