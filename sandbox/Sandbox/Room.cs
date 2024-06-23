public class Room
{
    private string name;
    private List<SmartDevice> devices = new List<SmartDevice>();

    public Room(string name)
    {
        this.name = name;
    }

    public void AddDevice(string name, string type)
    {
        SmartDevice deviceToAdd;
        if (type == SmartDevice.LIGHT)
        {
            deviceToAdd = new SmartLight(name);
        }
        else if (type == SmartDevice.HEATER)
        {
            deviceToAdd = new SmartHeater(name);
        }
        else if (type == SmartDevice.TV)
        {
            deviceToAdd = new SmartTV(name);
        }
    }

    public string GetName()
    {
        return name;
    }

    public void AllLightsOff() // turns off all lights
    {
        foreach (SmartDevice device in devices)
        {
            if (device.GetDeviceType() == SmartDevice.LIGHT)
            {
                device.TurnOff();
            }
        }
    }

    public void AllLightsOn() // turns on all lights
    {
        foreach (SmartDevice device in devices)
        {
            if (device.GetDeviceType() == SmartDevice.LIGHT)
            {
                device.TurnOn();
            }
        }
    }

    public void AllOff() // sets everthing to off
    {
        foreach (SmartDevice device in devices)
        {
            device.TurnOff();
        }
    }

    public void AllOn() // sets everything to on
    {
        foreach (SmartDevice device in devices)
        {
            device.TurnOn();
        }
    }

    public void PrintStatus() // prints each device and their status
    {
        Console.WriteLine(this.ToString());
    }

    public override string ToString()
    {
        string room = "[Name]\t[Type]\t[Is On]";
        foreach (SmartDevice device in devices)
        {
            room += $"\n{device.GetName()}\t{device.GetDeviceType()}\t{device.GetOnOff()}";
        }
        return room;
    }

    public void PrintOn() // prints a list of all the devices that are on
    {
        string devicesOn = "[Name]\t[Type]";
        foreach (SmartDevice device in devices)
        {
            devicesOn += $"\n{device.GetName()}\t{device.GetDeviceType()}";
        }
        Console.WriteLine(devicesOn);
    }

    public void PrintLongestOn() // prints the name and tpye of the device that has been on the longest
    {
        SmartDevice longestOn = devices[0];
        foreach (SmartDevice device in devices)
        {
            if (device.TimeOn() > longestOn.TimeOn())
            {
                longestOn = device;
            }
        }
        Console.WriteLine($"[Name]\t[Type]\n{longestOn.GetName()}\t{longestOn.GetDeviceType()}");
    }
}
