using Cubitwelve.Src.DTOs.Models;

namespace Cubitwelve.Src.Services.Interfaces
{
    public interface ICareersService
    {
        public Task<List<CareerDto>> GetAll();
    }
}