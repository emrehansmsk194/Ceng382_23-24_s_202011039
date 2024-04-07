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