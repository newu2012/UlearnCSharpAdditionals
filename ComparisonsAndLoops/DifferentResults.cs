namespace ComparisonsAndLoops;

public class DifferentResults
{
    private int x;

    public DifferentResults(int x)
    {
        this.x = x;
    }

    public bool CalculateFirstExpression() =>
        (x < 5) || (10 / x == 0);

    public bool CalculateSecondExpression() =>
        (x < 5) | (10 / x == 0);
}