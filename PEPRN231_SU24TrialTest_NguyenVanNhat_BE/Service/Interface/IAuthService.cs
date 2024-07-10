using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Models;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Interface
{
    public interface IAuthService
    {
        Task<UserAccount?> AuthenticateCustomer(string email, string hashedPassword);

        Task<string> GenerateAccessToken(string email, int? role);
    }
}
