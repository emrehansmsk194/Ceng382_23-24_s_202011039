using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApp1.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp1.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WebAppDatabaseContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(WebAppDatabaseContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Room> RoomsList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            RoomsList = await _context.rooms
                .Where(r => r.IsDeleted == false)
                .ToListAsync();
        }
    }
}
