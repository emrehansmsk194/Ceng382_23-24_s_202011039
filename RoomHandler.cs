using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

class RoomHandler{
    private string _filepath;
    public List<Room>GetRooms(){
        // Logic to read from JSON file
        try{
            string json = File.ReadAllText(_filepath);
            RoomData roomData = JsonSerializer.Deserialize<RoomData>(json);
            if (roomData?.Rooms != null)
            {
                return new List<Room>(roomData.Rooms);
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
            RoomData roomData = new RoomData {Rooms = rooms.ToArray()};
            string jsonString = JsonSerializer.Serialize(roomData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, jsonString);
        }
        catch(Exception ex){
            Console.WriteLine($"An error occurred while saving the rooms to the JSON file: {ex.Message}");
        }
    }


}