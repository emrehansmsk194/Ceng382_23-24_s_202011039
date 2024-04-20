using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

public interface IReservationService{
    void AddReservation(Reservation reservation, string reserverName);
    void DeleteReservation(Reservation reservation);
    void DisplayWeeklySchedule();

   

}