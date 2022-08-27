using System.Collections.Generic;
using System.Threading.Tasks;
using LoginAndStepper.ViewModels;

namespace LoginAndStepper.Managers
{
    public interface ITitleManager
    {
        Task<List<TitleVm>> GetAsync();
        Task AddAsync(TitleVm model);
        Task UpdateAsync(TitleVm model);
        Task DeleteAsync(int id);
        Task DeleteStepAsync(int stepNumber);
    }
}
