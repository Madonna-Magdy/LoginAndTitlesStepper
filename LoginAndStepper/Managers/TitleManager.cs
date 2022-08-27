using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAndStepper.Data;
using LoginAndStepper.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoginAndStepper.Managers
{
    public class TitleManager : ITitleManager
    {
        private readonly ApplicationDbContext _context;
        public TitleManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TitleVm>> GetAsync()
        {
            var res = await _context.Titles.AsQueryable()
                .Select(x => new TitleVm {Id = x.TitleId, Name = x.Name, Description = x.Description}).ToListAsync();

            return res;
        }

        public async Task AddAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
