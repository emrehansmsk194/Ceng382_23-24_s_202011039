using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApp1.Models;

public partial class Reservation
{
    public int Id { get; set; }

    [Required]
    public string? ReserverName { get; set; }
    [Required]
    public int? RoomId { get; set; }
    [Required]
    public DateTime Time { get; set; }

    public virtual ICollection<LogRecord> LogRecords { get; set; } = new List<LogRecord>();

    public virtual Room? Room { get; set; }
}
