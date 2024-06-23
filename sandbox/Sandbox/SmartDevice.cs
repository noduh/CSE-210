public abstract class SmartDevice
{
    // Static variables for the device types
    public static readonly string LIGHT = "Light";
    public static readonly string HEATER = "Heater";
    public static readonly string TV = "TV";

    protected string name; // name of the device
    protected long timeTurnedOn; // time in milliseconds (unix) when it was turned on. set to -1 if it's off
    protected bool isOn; // is it on
    protected string deviceType; // what kind of device is it

    public SmartDevice(string name, string deviceType)
    {
        this.name = name;
        this.deviceType = deviceType;
        this.isOn = false;
        this.timeTurnedOn = -1;
    }

    public void TurnOn()
    {
        timeTurnedOn = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        isOn = true;
    }

    public void TurnOff()
    {
        timeTurnedOn = -1;
    }

    public bool GetOnOff() // returns true if it's on
    {
        return isOn;
    }

    public long TimeOn() // returns the length it was on in milliseconds
    {
        long timeNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        return timeNow - timeTurnedOn;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDeviceType()
    {
        return deviceType;
    }
}
