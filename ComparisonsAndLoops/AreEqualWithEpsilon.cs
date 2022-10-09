namespace ComparisonsAndLoops;

public class AreEqualWithEpsilon
{
    private double a;
    private double b;
    private double eps;

    public AreEqualWithEpsilon(double a, double b, double eps)
    {
        this.a = a;
        this.b = b;
        this.eps = eps;
    }

    public bool AreEqual() => Math.Abs(a - b) <= eps;
}