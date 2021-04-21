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
    public class PermissionTypeController : ControllerBase
    {
        private readonly AplicationContext _context;
        public PermissionTypeController(AplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pTypes = _context.PermissionTypes.ToList();

            var pTypesDto = pTypes.Select(t => new PermissionTypeDTO 
            {
                         Id = t.Id,
                Description = t.Description
                  
            });

            return Ok(pTypesDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pType = _context.PermissionTypes.Find(id);

            if (pType == null) return NotFound();

            var pTypeDto = new PermissionTypeDTO 
            {
                         Id = pType.Id,
                Description = pType.Description
            };

            return Ok(pTypeDto);
        }
    }
}