using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

class ReservationService : IReservationService{
    private ReservationHandler _reservationHandler;

    public ReservationService(ReservationHandler reservationHandler){
        _reservationHandler = reservationHandler;
    }

    public void AddReservation(Reservation reservation, string reserverName){

    }
    public void DeleteReservation(Reservation reservation){

    }
    public void DisplayWeeklySchedule(){

    }

}