using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a test house and a test room and a test light with some other things
        House testHouse = new House("Test");
        testHouse.AddRoom("Room");
        testHouse.GetRoom("Room").AddDevice("light 1", SmartDevice.LIGHT);
        testHouse.GetRoom("Room").AddDevice("light 2", SmartDevice.LIGHT);
        testHouse.GetRoom("Room").AddDevice("light 1", SmartDevice.LIGHT); // should say it can't add it
        testHouse.GetRoom("Room").AddDevice("heater", SmartDevice.HEATER);
        testHouse.GetRoom("Room").AddDevice("tv", SmartDevice.TV);

        // test on and off and print status
        testHouse.GetRoom("Room").AllLightsOn();
        testHouse.GetRoom("Room").PrintStatus();
        testHouse.GetRoom("Room").AllLightsOff();
        testHouse.GetRoom("Room").PrintStatus();

        // test all on and all off and getting the longest on and getting all that are on
        testHouse.GetRoom("Room").AllOn();
        testHouse.GetRoom("Room").PrintLongestOn();
        testHouse.GetRoom("Room").PrintOn();
        testHouse.GetRoom("Room").AllOff();
    }
}