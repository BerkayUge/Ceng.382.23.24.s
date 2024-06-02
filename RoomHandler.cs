using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class RoomHandler
{
    public class RoomHandler
{
    private readonly string _filePath;

    public RoomHandler(string filePath)
    {
        _filePath = filePath;
    }

    public List<Room> GetRooms()
    {
        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Room>>(json);
    }

    public void SaveRooms(List<Room> rooms)
    {
        string json = JsonSerializer.Serialize(rooms);
        File.WriteAllText(_filePath, json);
    }
}
}
