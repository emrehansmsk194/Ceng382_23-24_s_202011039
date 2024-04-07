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
// buralar doldurulacak.
}

public void DeleteReservation(Reservation reservation){

// buralar doldurulacak.

}
public List<Reservation> GetAllReservations(){

}
public List<Room> GetRooms(){

}
public List<Room> SaveRooms(List<Room> rooms){
    
}







}