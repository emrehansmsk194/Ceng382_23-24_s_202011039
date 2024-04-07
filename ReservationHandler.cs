using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;


class ReservationHandler {
private IReservationRepository _reservationRepository; 
private LogHandler _logHandler;

private RoomHandler _roomHandler;

public ReservationHandler(IReservationRepository reservationRepository, LogHandler logHandler, RoomHandler roomHandler){
  _reservationRepository = reservationRepository;
  _logHandler = logHandler;
  _roomHandler = roomHandler;


}

public void AddReservation(Reservation reservation){

  _reservationRepository.AddReservation(reservation);
   var log = new LogRecord(DateTime.Now,reservation.reserverName, $"Added Reservation: {reservation.room.RoomName}");
  _logHandler.AddLog(log);
}

public void DeleteReservation(Reservation reservation){
  _reservationRepository.DeleteReservation(reservation);
  var log = new LogRecord(DateTime.Now,reservation.reserverName, $"Deleted Reservation: {reservation.room.RoomName}");
  _logHandler.AddLog(log);
}
public List<Reservation> GetAllReservations(){
  return _reservationRepository.GetAllReservations();
}
public List<Room> GetRooms(){
      string jsonFilePath = "Data.json"; 
      string jsonString = File.ReadAllText(jsonFilePath);
      var roomData = JsonSerializer.Deserialize<RoomData>(jsonString);
      return roomData?.Rooms.ToList() ?? new List<Room>();
}
public void SaveRooms(List<Room> rooms){
     var roomData = new RoomData { Rooms = rooms.ToArray() };
     string jsonString = JsonSerializer.Serialize(roomData, new JsonSerializerOptions { WriteIndented = true });
     File.WriteAllText("Data.json", jsonString); 
}







}