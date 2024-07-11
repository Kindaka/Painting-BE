using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Implement;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Interface;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StyleController : ControllerBase
    {

        private readonly IStyleService _styleService;

        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        [Authorize(Policy = "RequireStaffOrManagerRole")]
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAllStyle()
        {
            try
            {
                var styles = await _styleService.GetStyle();
                return Ok(styles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
