using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
public record LogRecord(DateTime Timestamp, string reserverName, string roomName);
public record Room(
    [property: JsonPropertyName("roomId")] string RoomId,
    [property: JsonPropertyName("roomName")] string RoomName,
    [property: JsonPropertyName("capacity")] int Capacity);
public record Reservation(DateTime time, DateTime date, string reserverName, Room room);

public class RoomData {

    public Room[]? Room { get; set; }
}

class Program {

   public static Random random= new Random();

 
    static void DeleteReservation(ReservationHandler reservationHandler)
{
    var reservations = reservationHandler.GetAllReservations();
    if (reservations.Count == 0)
    {
        Console.WriteLine("There are no reservations to delete.");
        return;
    }

    Console.WriteLine("Please select a reservation to delete:");
    for (int i = 0; i < reservations.Count; i++)
    {
        var reservation = reservations[i];
        Console.WriteLine($"{i + 1}. Reservation for {reservation.room.RoomName} by {reservation.reserverName} on {reservation.date.ToShortDateString()} at {reservation.time.ToShortTimeString()}");
    }

    Console.Write("Choice (enter number): ");
    if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= reservations.Count)
    {
        var selectedReservation = reservations[index - 1];
        reservationHandler.DeleteReservation(selectedReservation);
        Console.WriteLine("Reservation deleted successfully.");
    }
    else
    {
        Console.WriteLine("Invalid selection.");
    }
}

    static void Main(string [] args)
    {
    string logFilePath = "LogData.json"; 
    string reservationDataFilePath = "ReservationData.json"; 
    string roomsDataFilePath = "Data.json";
    string json = File.ReadAllText("Data.json");
    int randomIndex;
    RoomData roomData = JsonSerializer.Deserialize<RoomData>(json);
   
    
    // create LogHandler and FileLogger objects
    ILogger fileLogger = new FileLogger(logFilePath);
    LogHandler logHandler = new LogHandler(fileLogger);

    // create ReservationRepository and RoomHandler objects
    IReservationRepository reservationRepository = new ReservationRepository(reservationDataFilePath, fileLogger);
    RoomHandler roomHandler = new RoomHandler(roomsDataFilePath);

    // create ReservationHandler object
    ReservationHandler reservationHandler = new ReservationHandler(reservationRepository, logHandler, roomHandler);
   // create ReservationService object
    ReservationService reservationService = new ReservationService(reservationHandler);


    Console.WriteLine("Available Rooms:");
    Thread.Sleep(1000);
    var rooms = RoomHandler.GetRooms();
    foreach (var room in rooms)
    {
        Console.WriteLine($"Room Name: {room.RoomName}, Capacity: {room.Capacity}");
    }

    Console.WriteLine("\nReservations of This Week:");
    reservationService.DisplayWeeklySchedule();

   
    bool process = true;
    while(process){
        Console.WriteLine("\nPlease Select a transaction: ");
        Console.WriteLine("1. Create New Reservation");
        Console.WriteLine("2. Delete a Reservation");
        Console.WriteLine("3. View the Reservations of this week");
        Console.WriteLine("4. Exit");
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        switch(choice){
            case "1":
                randomIndex = random.Next(roomData.Room.Length);
                Room room = roomData.Room[randomIndex];
                Console.WriteLine("Enter your Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    return; 
                }
                Console.WriteLine("Your reservation successfully created.");
                Reservation r = new Reservation(DateTime.Now,DateTime.Now,name,room);
                reservationHandler.AddReservation(r);
                Thread.Sleep(1000);
                break;
            case "2":
                DeleteReservation(reservationHandler);
                Thread.Sleep(1000);
                break;
            case "3":
                reservationService.DisplayWeeklySchedule();
                Thread.Sleep(1000);
                break;
            case "4":
                process = false;
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
                    





        }


    }


   
       
     
      
            
        }
      

     


        }



      

    



    



