using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

class ReservationRepository: IReservationRepository{

    public List <Reservation> _reservations = new List<Reservation>();
    private readonly string _reservationDataFilePath;
    private readonly ILogger _logger;

    public ReservationRepository(string reservationDataFilePath, ILogger logger)
    {
        _reservationDataFilePath = reservationDataFilePath;
        _logger = logger;
    }

    public void AddReservation(Reservation reservation){
        _reservations.Add(reservation);
        UpdateReservationDataFile();
        _logger.Log(new LogRecord(DateTime.Now,reservation.reserverName, $"Added Reservation: {reservation.room.RoomName}"));


    }
    public void DeleteReservation(Reservation reservation){
        _reservations.Remove(reservation);
        UpdateReservationDataFile();
        _logger.Log(new LogRecord(DateTime.Now,reservation.reserverName, $"Deleted Reservation: {reservation.room.RoomName}"));
    }
    public List<Reservation> GetAllReservations(){
        return _reservations;
    }
    
    public void UpdateReservationDataFile(){
        var reservationJson = JsonSerializer.Serialize(_reservations, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(_reservationDataFilePath,reservationJson);    
    }

}