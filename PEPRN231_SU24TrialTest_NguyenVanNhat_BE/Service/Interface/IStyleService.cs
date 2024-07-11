using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Models;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Interface
{
    public interface IStyleService
    {
        Task<List<Style>> GetStyle();
    }
}
