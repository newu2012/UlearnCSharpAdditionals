namespace ComparisonsAndLoops;

public class ShortenTheCode
{
    private static int a = 5;
    private static int b = 6;
    
    public static bool LongCode()
    {
        if (a == b) return true;
        else return false;
    }

    public static bool ShortCode() => a == b;
}