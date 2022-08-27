using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAndStepper.Data;
using LoginAndStepper.Models;
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
                .Select(x => new TitleVm
                    {Id = x.TitleId, Name = x.Name, Description = x.Description, StepNumber = x.StepNumber})
                .ToListAsync();

            return res;
        }

        public async Task AddAsync(TitleVm model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("The title is required");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                throw new ArgumentException("The description is required");
            }

            var title = new Title
            {
                Name = model.Name,
                Description = model.Description,
                StepNumber = model.StepNumber
            };

            await _context.Titles.AddAsync(title);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TitleVm model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("The title is required");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                throw new ArgumentException("The description is required");
            }



            var title = await _context.Titles.FirstOrDefaultAsync(x => x.TitleId == model.Id);

            if (title == null)
            {
                throw new Exception("Invalid title");
            }

            title.Name = model.Name;
            title.Description = model.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var title = await _context.Titles.FirstOrDefaultAsync(x => x.TitleId == id);

            if (title == null)
            {
                throw new Exception("Invalid title");
            }

            _context.Titles.Remove(title);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStepAsync(int stepNumber)
        {
            var titles = await _context.Titles.AsQueryable().Where(x => x.StepNumber == stepNumber).ToListAsync();

            if (titles.Any())
            {
                _context.Titles.RemoveRange(titles);
                await _context.SaveChangesAsync();
            }
        }
    }
}
