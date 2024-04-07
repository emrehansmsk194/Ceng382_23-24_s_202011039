using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
public record LogRecord(DateTime Timestamp, string reserverName, string roomName);
public record Room(
    [property: JsonPropertyName("roomId")] string RoomId,
    [property: JsonPropertyName("roomName")] string RoomName,
    [property: JsonPropertyName("capacity")] int Capacity);
public record Reservation(DateTime time, DateTime date, string reserverName, Room room);


class Program {

   

 
    
    static void Main(string [] args)
    {
        
       
     
      
            
        }
      

     


        }



      

    



    
}


