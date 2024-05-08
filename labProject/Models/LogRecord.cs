
public class LogRecord{
    public int Id { get; set; }

    public DateTime? Timestamp { get; set; }

    // foreign keys
    public int? ReservationId { get; set; }
    public int? RoomId { get; set; }

    // Navigation properties

    public Reservation? Reservation { get; set; }
    public Room? Room { get; set; }




}