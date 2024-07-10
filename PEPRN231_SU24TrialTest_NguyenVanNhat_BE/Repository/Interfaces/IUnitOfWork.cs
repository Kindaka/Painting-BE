using Microsoft.EntityFrameworkCore.Storage;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Models;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Style> StyleRepository { get; }
        IGenericRepository<UserAccount> UserAccountRepository { get; }
        IGenericRepository<WatercolorsPainting> WatercolorsPaintingRepository { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task SaveAsync();
    }
}
