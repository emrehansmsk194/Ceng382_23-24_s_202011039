using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace MyApp.Namespace
{
    public class EditReservationModel : PageModel
    {
        private readonly WebAppDatabaseContext _context;
        private readonly ILogger<EditReservationModel> _logger;

        public EditReservationModel(WebAppDatabaseContext context, ILogger<EditReservationModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }
        public IList<Room> RoomsList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reservation = await _context.reservations.FindAsync(id);

            if (Reservation == null)
            {
                _logger.LogWarning("Reservation ID {ReservationId} was not found.", id);
                return NotFound();
            }

            RoomsList = await _context.rooms.Where(r => r.IsDeleted.HasValue && r.IsDeleted.Value == false).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                RoomsList = await _context.rooms.Where(r => r.IsDeleted.HasValue && r.IsDeleted.Value == false).ToListAsync();
                return Page();
            }

            var reservationToUpdate = await _context.reservations.FindAsync(Reservation.Id);

            if (reservationToUpdate == null)
            {
                _logger.LogWarning("Reservation ID {ReservationId} was not found during the update.", Reservation.Id);
                return NotFound();
            }

            reservationToUpdate.RoomId = Reservation.RoomId;
            reservationToUpdate.Time = Reservation.Time;
            reservationToUpdate.ReserverName = Reservation.ReserverName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ReservationExists(Reservation.Id).GetValueOrDefault())
                {
                    _logger.LogWarning("Reservation ID {ReservationId} no longer exists.", Reservation.Id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, "A concurrency error occurred while updating the reservation ID {ReservationId}.", Reservation.Id);
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the reservation ID {ReservationId}.", Reservation.Id);
                return StatusCode(500, "Server error");
            }

            return RedirectToPage("/ShowReservations");
        }

        private bool? ReservationExists(int id)
        {
            return _context.reservations.Any(e => e.Id == id);
        }
    }
}
