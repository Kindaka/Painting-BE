using Microsoft.AspNetCore.OData.Deltas;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Models;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.ModelView;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Interface
{
    public interface IWatercolorsPaintingService
    {
        Task<List<WatercolorsPainting>> Get();

        Task<WatercolorsPainting?> Get(string key);

        Task Post(WatercolorsPainting watercolorsPainting);

        Task Put(WatercolorsPainting watercolorsPainting);

        Task Delete(WatercolorsPainting painting);

        Task<List<WatercolorsPainting>> Search(string author, int? year);
    }
}
