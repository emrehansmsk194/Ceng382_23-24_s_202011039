using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? RoomName { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please give a positive integer number.")]
    public int? Capacity { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<LogRecord> LogRecords { get; set; } = new List<LogRecord>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
