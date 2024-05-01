using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RoomHandler{
    private static string _filepath;
    public RoomHandler(string filepath)
    {
        _filepath = filepath;
    }
    public static List<Room>GetRooms(){
        // Logic to read from JSON file
        try{
            string json = File.ReadAllText(_filepath);
            RoomData? roomData = JsonSerializer.Deserialize<RoomData>(json);
            if (roomData?.Room != null)
            {
                return new List<Room>(roomData.Room);
            }
            else
            {
                return new List<Room>();
            }
        }
        catch(Exception ex){
            Console.WriteLine($"An error occurred while reading the rooms from the JSON file: {ex.Message}");
            return new List<Room>();
        }
    }
    public void SaveRoom(List<Room> rooms){
        try{
            RoomData roomData = new RoomData {Room = rooms.ToArray()};
            string jsonString = JsonSerializer.Serialize(roomData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
        }
        catch(Exception ex){
            Console.WriteLine($"An error occurred while saving the rooms to the JSON file: {ex.Message}");
        }
    }
    public static List<string> GetRoomByNameId(string roomId){
        List<Room> rooms= GetRooms();
        var matching_rooms = rooms.Where(r => r.RoomId == roomId).Select(r => r.RoomName).ToList();
        return matching_rooms;
        

        }
    }


