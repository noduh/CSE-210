class Fraction
{
    private int top;
    private int bottom;

    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        top = wholeNumber;
        bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        this.top = top;
        this.bottom = bottom;
    }

    public int GetTop()
    {
        return top;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetTop(int top)
    {
        this.top = top;
    }

    public void SetBottom(int bottom)
    {
        this.bottom = bottom;
    }

    public string GetFractionString()
    {
        string fractionString = $"{top}/{bottom}";
        return fractionString;
    }

    public double GetFractionDecimal()
    {
        double fractionDecimal = (double)top / bottom;
        return fractionDecimal;
    }
}
