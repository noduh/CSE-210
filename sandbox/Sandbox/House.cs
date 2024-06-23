public class House
{
    private string name;
    private List<Room> rooms = new List<Room>();

    public House(string name)
    {
        this.name = name;
    }

    public void AddRoom(string name)
    {
        rooms.Add(new Room(name));
    }

    public void RemoveRoom(string roomName)
    {
        foreach (Room room in rooms)
        {
            if (room.GetName() == roomName)
            {
                rooms.Remove(room);
            }
        }
    }

    public Room GetRoom(string roomName)
    {
        foreach (Room room in rooms)
        {
            if (room.GetName() == roomName)
            {
                return room;
            }
        }
        return null;
    }
}
