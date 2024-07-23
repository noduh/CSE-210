using System.Text.Json.Serialization;

public class Response
{
    [JsonInclude]
    private bool allowed;

    [JsonInclude]
    private int code; // will be implemented later

    [JsonInclude]
    private string reason;

    [JsonInclude]
    private int followingDataSize = 0; // will be implemented later

    [JsonInclude]
    private string followingDataType = ""; // will be implemented later

    public Response(bool allowed, int code)
    {
        this.allowed = allowed;
        this.code = code;
    }

    public Response(bool allowed, int code, string reason)
    {
        this.allowed = allowed;
        this.code = code;
        this.reason = reason;
    }
}
