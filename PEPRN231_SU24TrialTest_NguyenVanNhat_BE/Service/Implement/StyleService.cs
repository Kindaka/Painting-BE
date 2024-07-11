using AutoMapper;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Models;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Repository.Interfaces;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Interface;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Implement
{
    public class StyleService : IStyleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StyleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<Style>> GetStyle()
        {
            try
            {
                var styles = (await _unitOfWork.StyleRepository.GetAsync()).ToList();
                return styles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
