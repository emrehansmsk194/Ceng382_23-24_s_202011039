using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

public class LogHandler{
    private ILogger _logger;
    public LogHandler(ILogger logger){
        _logger = logger;
    }
    public void AddLog(LogRecord log){
        _logger.Log(log);
    }

}