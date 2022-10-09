namespace ComparisonsAndLoops;

public class AlwaysCalled
{
    private bool fValue;
    private bool gValue;
    private bool hValue;

    public AlwaysCalled(bool f, bool g, bool h)
    {
        fValue = f;
        gValue = g;
        hValue = h;
    }

    public void CallMethods()
    {
        // Change f return value to swap
        var a = (true && f()) && g() || h();
    }

    private bool f()
    {
        Console.WriteLine("F");
        return fValue;
    }

    private bool g()
    {
        Console.WriteLine("G");
        return gValue;
    }

    private bool h()
    {
        Console.WriteLine("H");
        return hValue;
    }
}