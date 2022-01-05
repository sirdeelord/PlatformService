using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

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
            Console.WriteLine("=====> Preparing to get all platforms");
            var platforms = await _platformRepo.GetAllPlatformsAsync();
            var platformReadDTO = _mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
            return Ok(platformReadDTO);
        }

    
    }
}