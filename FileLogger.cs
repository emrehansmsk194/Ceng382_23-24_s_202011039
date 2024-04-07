using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

public class FileLogger : ILogger{
    private readonly string _logFilepath; // readonly => yalnizca constructorda deger atanabilir

    public FileLogger(string logFilepath){
        _logFilepath = logFilepath;
    }
    public void Log(LogRecord log){
        var logJson = JsonSerializer.Serialize(log, new JsonSerializerOptions{WriteIndented = true});
        File.AppendAllText(_logFilepath, logJson + Environment.NewLine);
    }
}
