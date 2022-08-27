using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LoginAndStepper.Managers;
using LoginAndStepper.ViewModels;

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

        [HttpPost]
        public async Task<IActionResult> Add(TitleVm model)
        {
            await _titleManager.AddAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TitleVm model)
        {
            await _titleManager.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _titleManager.DeleteAsync(id);
            return Ok();
        }

        [HttpDelete("deleteStep/{stepNumber}")]
        public async Task<IActionResult> DeleteStep(int stepNumber)
        {
            await _titleManager.DeleteStepAsync(stepNumber);
            return Ok();
        }
    }
}
