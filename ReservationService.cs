using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

 public  class ReservationService : IReservationService{
    private static ReservationHandler _reservationHandler;

    public static List<Reservation> reservations = new List<Reservation>();

    public static void InitializeReservations(string jsonFilePath){
        try{
            string jsonString = File.ReadAllText(jsonFilePath);
            reservations = JsonSerializer.Deserialize<List<Reservation>>(
            jsonString,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
            ) ?? new List<Reservation>();
        }
        catch(JsonException ex){
            Console.WriteLine("An error occured while processing the Json file" + ex.Message);
        }
        catch(FileNotFoundException ex){
            Console.WriteLine("Json File not found." + ex.Message);
        }
        catch(Exception ex){
            Console.WriteLine("An unexpected error occured." + ex.Message);
        }   
        
    }


    public static void PrintReservations()
    {
         foreach (var reservation in reservations){
            Console.WriteLine($"DataTime: {reservation.date}, Reserver: {reservation.reserverName}, Room: {reservation.room}");
         }

    }
    public static void PrintReservations(List<Reservation> reservations){
        foreach (var reservation in reservations){
            Console.WriteLine($"DataTime : {reservation.date}, Reserver : {reservation.reserverName}, Room : {reservation.room} , Capacity : {reservation.room.Capacity}");
        }

    }

    public static void DisplayReservationByReserver(string name){
        var filteredReservations = filterByName(name);
    if (filteredReservations.Count == 0)
        {
        Console.WriteLine($"\nNo reservations found for: {name}");
        }
    else
        {
        Console.WriteLine($"\nReservations for {name}:");
        PrintReservations(filteredReservations);
        }
    }
     private static List<Reservation> filterByName ( string name)
    {
        var filteredReservations = reservations.Where(r => r.reserverName.Equals(name,StringComparison.OrdinalIgnoreCase)).ToList();
        return filteredReservations;
    }

    public static void DisplayReservationByRoomId(string Id){
    var roomName = RoomHandler.GetRoomByNameId(Id);
    var filteredReservations = filterByRoomId(Id);
    if(filteredReservations.Count == 0){
         Console.WriteLine($"\nNo reservations found for: {Id}");
    }
    else{
        if (roomName != null && roomName.Count > 0){
            foreach (var room in roomName){
                Console.WriteLine($"\n Reservations for {room}:");
                PrintReservations(filteredReservations);
            }
    }
        else{   
            Console.WriteLine("\nRoomID does not exist.");
            }
    }

   
}
    private static List<Reservation> filterByRoomId (string Id){
        var filteredReservations = reservations.Where(r => r.room.RoomId.Equals(Id,StringComparison.OrdinalIgnoreCase)).ToList();
        return filteredReservations;
    }


    public ReservationService(ReservationHandler reservationHandler){
        _reservationHandler = reservationHandler;
    }

    public void AddReservation(Reservation reservation, string reserverName){
        
        _reservationHandler.AddReservation(reservation);


    }
    public void DeleteReservation(Reservation reservation){
        _reservationHandler.DeleteReservation(reservation);
    }
    public void DisplayWeeklySchedule(){
        var allReservations = _reservationHandler.GetAllReservations();
        var weekStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday);
        var weekEnd = weekStart.AddDays(7);
        List<Reservation> thisWeekReservations = new List<Reservation>();

        foreach (var reservation in allReservations)
        {
            if (reservation.date >= weekStart && reservation.date < weekEnd)
            {
                thisWeekReservations.Add(reservation);
            }
        }

         foreach (var reservation in thisWeekReservations)
        {
            Console.WriteLine($"{reservation.date.ToShortDateString()} - {reservation.time.ToShortTimeString()}, {reservation.room.RoomName}, Reserved by: {reservation.reserverName}");
        }

    }

}