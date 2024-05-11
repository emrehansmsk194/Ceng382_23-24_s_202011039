using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;

namespace MyApp.Namespace
{
    
    public class CreateRoomModel : PageModel
    {
        [BindProperty]
        public Room NewRoom { get; set; } = new Room();
        public WebAppDatabaseContext ToDo= new();
        
        public void OnGet()
        {
            
        }
        public IActionResult OnPost(){
            if (!ModelState.IsValid || NewRoom == null)
            {
                return Page();
            }
            NewRoom.IsDeleted = false;
            ToDo.Add(NewRoom);
            ToDo.SaveChanges();
            return RedirectToPage("/ShowRooms");
        }
    }
}