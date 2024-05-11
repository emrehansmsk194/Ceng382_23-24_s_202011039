using System;
using System.Collections.Generic;

namespace WebApp1.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public string? ReserverName { get; set; }

    public int? RoomId { get; set; }

    public DateTime Time { get; set; }

    public DateOnly Date { get; set; }

    public virtual ICollection<LogRecord> LogRecords { get; set; } = new List<LogRecord>();

    public virtual Room? Room { get; set; }
}
