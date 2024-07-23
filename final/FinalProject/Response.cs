public class Response
{
    private bool isError;
    private int code; // will be implemented later
    private string explanation;
    private int followingDataSize = 0; // will be implemented later
    private string followingDataType = ""; // will be implemented later

    public Response(bool isError, int code)
    {
        this.isError = isError;
        this.code = code;
    }

    public Response(bool isError, int code, string explanation)
    {
        this.isError = isError;
        this.code = code;
        this.explanation = explanation;
    }
}
