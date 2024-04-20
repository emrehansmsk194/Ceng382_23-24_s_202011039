using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class LogService{

    public record LogEntry(string TimeStamp, string ReserverName, string RoomName);

    public record Reservation(DateTime Date, string ReserverName, string RoomName);

    public static List<Reservation> logs = new List<Reservation>();

    public static void InitializeLogs(string jsonFilePath)
    {
        string jsonString = File.ReadAllText(jsonFilePath);
        logs = JsonSerializer.Deserialize<List<LogEntry>>(jsonString) .Select(log => new Reservation(
                DateTime.Parse(log.TimeStamp), 
                log.ReserverName,
                log.RoomName
            )).ToList();
    }

    public static List<Reservation> DisplayLogsByName(string name){
        return logs.Where(r => r.ReserverName.Equals(name,StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public static List<Reservation> DisplayLogs(DateTime start, DateTime end){
        return logs.Where(r=> r.Date >= start && r.Date <= end).ToList();
    }
}