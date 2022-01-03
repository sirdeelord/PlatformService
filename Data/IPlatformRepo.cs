using System.Collections.Generic;
using System.Threading.Tasks;
using PlatformService.Entities;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform> GetPlatformByIdAsync(int id);
        Task<Platform> CreatePlatformAsync(Platform platform);
        Task<bool> SaveChangesAsync();
    }
}