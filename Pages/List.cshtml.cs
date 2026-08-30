using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FeedbackApp.Data;
using FeedbackApp.Models;

namespace FeedbackApp.Pages
{
    public class ListModel : PageModel
    {
        private readonly AppDbContext _context;

        public ListModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Experience> Experiences { get; set; }
        public List<Region> Regions { get; set; }
        public List<Wilaya> Wilayas { get; set; }
        public List<Area> Areas { get; set; }
        public List<Village> Villages { get; set; }

        public async Task OnGetAsync(int? RegionId, int? WilayaId, int? AreaId, int? VillageId)
        {
            Regions = await _context.Regions.ToListAsync();
            Wilayas = await _context.Wilayas.ToListAsync();
            Areas = await _context.Areas.ToListAsync();
            Villages = await _context.Villages.ToListAsync();

            var query = _context.Experiences
                .Include(e => e.Region)
                .Include(e => e.Wilaya)
                .Include(e => e.Area)
                .Include(e => e.Village)
                .AsQueryable();

            if (RegionId.HasValue) query = query.Where(e => e.RegionId == RegionId.Value);
            if (WilayaId.HasValue) query = query.Where(e => e.WilayaId == WilayaId.Value);
            if (AreaId.HasValue) query = query.Where(e => e.AreaId == AreaId.Value);
            if (VillageId.HasValue) query = query.Where(e => e.VillageId == VillageId.Value);

            Experiences = await query.ToListAsync();
        }
    }
}
