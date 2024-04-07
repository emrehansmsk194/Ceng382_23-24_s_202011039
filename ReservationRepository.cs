using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

class ReservationRepository: IReservationRepository{

    public List <Reservation> _reservations = new List<Reservation>();

    public void AddReservation(Reservation reservation){
        _reservations.Add(reservation);
        // Update ReservationData.json
    }
    public void DeleteReservation(Reservation reservation){
        _reservations.Remove(reservation);
    }
    public List<Reservation> GetAllReservations(){
        return _reservations;
    }
    

}