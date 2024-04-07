using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

public interface ILogger{
    void Log(LogRecord log);
}