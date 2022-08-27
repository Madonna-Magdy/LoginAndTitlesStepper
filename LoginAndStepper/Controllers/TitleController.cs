using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LoginAndStepper.Managers;

namespace LoginAndStepper.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TitleController : ControllerBase
    {

        private readonly ITitleManager _titleManager;

        public TitleController(ITitleManager titleManager)
        {
            _titleManager = titleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _titleManager.GetAsync();
            return Ok(res);
        }
    }
}
