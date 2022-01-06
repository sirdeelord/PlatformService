using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Entities;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDTO>>> GetPlatformsAsync()
        {
            var platforms = await _platformRepo.GetAllPlatformsAsync();
            var platformReadDTO = _mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
            return Ok(platformReadDTO);
        }

        [HttpGet("{id}", Name = "GetPlatformByIdAsync")]
        public async Task<ActionResult<PlatformReadDTO>> GetPlatformByIdAsync(int id)
        {
            var platform = await _platformRepo.GetPlatformByIdAsync(id);
            if (platform == null)
            {
                return NotFound();
            }
            var platformReadDTO = _mapper.Map<PlatformReadDTO>(platform);
            return Ok(platformReadDTO);
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDTO>> CreatePlatformAsync(PlatformCreateDTO platformCreateDTO)
        {
            var platform = _mapper.Map<Platform>(platformCreateDTO);
            await _platformRepo.CreatePlatformAsync(platform);
            var platformReadDTO = _mapper.Map<PlatformReadDTO>(platform);
            return CreatedAtRoute(nameof(GetPlatformByIdAsync), new { Id = platformReadDTO.Id }, platformReadDTO);
        }

    
    }
}