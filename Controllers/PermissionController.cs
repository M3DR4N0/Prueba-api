using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            var permission = _context.Permissions.ToList();

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

        [HttpGet]
        public IActionResult Get(int id)
        {
            var permission = _context.Permissions.Find(id);

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
        public IActionResult Post(PermissionDTO permissionDto)
        {
            var permission = new Permission 
            {
                EmpName = permissionDto.EmpName,
                EmpLastName = permissionDto.EmpLastName,
                PType = permissionDto.PType,
            };

            permissionDto.Id = permission.Id;

            _context.Permissions.Add(permission);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = permissionDto.Id }, permissionDto);
        }

        [HttpPut]
        public IActionResult Put(int id, PermissionDTO permissionDto)
        {
            var permission = _context.Permissions.Find(id);

            if (permission == null) return NotFound();

            permission.EmpName = permissionDto.EmpName;
            permission.EmpLastName = permissionDto.EmpLastName;
            permission.PType = permissionDto.PType;
            
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var permission = _context.Permissions.Find(id);

            if (permission == null) return NotFound();

            _context.Permissions.Remove(permission);
            _context.SaveChanges();

            return NoContent();
        }
    }
}