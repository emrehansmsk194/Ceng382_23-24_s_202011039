using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace MyApp.Namespace
{
    public class ShowRoomModel : PageModel
    {
        public AppDbContext Rooms = new();
        public List<Room> RoomsList{get;set;} = default!;
        public void OnGet()
        {
            RoomsList = (from item in Rooms.rooms
            where item.IsDeleted == false
            select item).ToList();
        }
        public IActionResult OnPostDelete(int id){
            if(Rooms.rooms != null){
                var room = Rooms.rooms.Find(id);
                if(room != null){
                    room.IsDeleted = true;
                    Rooms.SaveChanges();
                }    
            }
            return RedirectToAction("Get");
        }

    }
}
