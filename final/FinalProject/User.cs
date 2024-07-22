public class User
{
    public const string Player = "player";
    public const string Observer = "observer";
    public const string White = "white";
    public const string Black = "black";

    private string name;
    private string side;

    public User(string name)
    {
        this.name = name;
        this.side = Observer;
    }

    public string GetName()
    {
        return name;
    }

    public string GetSide()
    {
        return side;
    }

    public void BecomePlayer(string color)
    {
        side = color;
    }

    public bool IsPlayer()
    {
        return side == White || side == Black;
    }
}
