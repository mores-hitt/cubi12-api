using Cubitwelve.Src.DTOs.Models;
using Cubitwelve.Src.Models;
using Cubitwelve.Src.Repositories.Interfaces;
using Cubitwelve.Src.Services.Interfaces;

namespace Cubitwelve.Src.Services
{
    public class CareersService : ICareersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;

        public CareersService(IUnitOfWork unitOfWork, IMapperService mapperService)
        {
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
        }

        public async Task<List<CareerDto>> GetAll()
        {
            var careers = await _unitOfWork.CareersRepository.Get();
            return _mapperService.MapList<Career, CareerDto>(careers);
        }
    }
}