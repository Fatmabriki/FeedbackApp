using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FeedbackApp.Data;
using FeedbackApp.Models;

namespace FeedbackApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Experience Experience { get; set; }

        public System.Collections.Generic.List<Region> Regions { get; set; }

        public async Task OnGetAsync()
        {
            Regions = await _context.Regions.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Regions = await _context.Regions.ToListAsync();
                return Page();
            }

            _context.Experiences.Add(Experience);
            await _context.SaveChangesAsync();

            return RedirectToPage("List");
        }

        public async Task<JsonResult> OnGetWilayasAsync(int parentId)
        {
            var wilayas = await _context.Wilayas
                .Where(w => w.RegionId == parentId)
                .Select(w => new { id = w.Id, name = w.Name })
                .ToListAsync();

            return new JsonResult(wilayas);
        }

        public async Task<JsonResult> OnGetAreasAsync(int parentId)
        {
            var areas = await _context.Areas
                .Where(a => a.WilayaId == parentId)
                .Select(a => new { id = a.Id, name = a.Name })
                .ToListAsync();

            return new JsonResult(areas);
        }

        public async Task<JsonResult> OnGetVillagesAsync(int parentId)
        {
            var villages = await _context.Villages
                .Where(v => v.AreaId == parentId)
                .Select(v => new { id = v.Id, name = v.Name })
                .ToListAsync();

            return new JsonResult(villages);
        }
    }
}
