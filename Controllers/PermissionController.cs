using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_api.Data;
using prueba_api.Models;
using prueba_api.Models.DTO;

namespace prueba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly AplicationContext _context;

        public PermissionController(AplicationContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permission = await _context.Permissions.ToListAsync();

            var permissionDto = permission.Select(p => new PermissionDTO 
            {
                         Id = p.Id,
                    EmpName = p.EmpName,
                EmpLastName = p.EmpLastName,
                      PType = p.PType,
                      PDate = p.PDate
            });

            return Ok(permissionDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null) return NotFound();

            var permissionDto = new PermissionDTO 
            {
                         Id = permission.Id,
                    EmpName = permission.EmpName,
                EmpLastName = permission.EmpLastName,
                      PType = permission.PType,
                      PDate = permission.PDate
            };

            return Ok(permissionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermissionDTO permissionDto)
        {
            var permission = new Permission 
            {
                EmpName = permissionDto.EmpName,
                EmpLastName = permissionDto.EmpLastName,
                PType = permissionDto.PType,
                PDate = permissionDto.PDate
            };

            if (permission.EmpName == "" || permission.EmpLastName == ""  || permission.PType.Equals(0)) 
                return BadRequest( new { message = "No se aceptan campos vacios." });

            if (permission.PDate >= DateTime.Now)
            {
                await _context.Permissions.AddAsync(permission);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest( new { message = "La fecha ingresada no puede ser menor a la de hoy." });
            }            

            permissionDto.Id = permission.Id;
            
            return CreatedAtAction(nameof(Get), new { id = permissionDto.Id }, permissionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PermissionDTO permissionDto)
        {
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null) return NotFound();

            permission.EmpName = permissionDto.EmpName;
            permission.EmpLastName = permissionDto.EmpLastName;
            permission.PType = permissionDto.PType;
            permission.PDate = permissionDto.PDate;

             if (permission.EmpName == "" || permission.EmpLastName == "" || permission.PDate == DateTime.MinValue || permission.PType.Equals(0)) 
                return BadRequest( new { message = "No se aceptan campos vacios." });

            if (permission.PDate >= DateTime.Now)
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest( new { message = "La fecha ingresada no puede ser menor a la de hoy" });
            }    

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null) return NotFound();

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}