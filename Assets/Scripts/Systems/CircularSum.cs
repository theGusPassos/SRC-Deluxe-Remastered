public class CircularSum
{
    private readonly int maxSum;
    private int currentValue;

    public CircularSum(int maxSum)
    {
        this.maxSum = maxSum;
    }

    public int Add()
    {
        if (++currentValue > maxSum)
            currentValue = 0;

        return currentValue;
    }

    public int Subtract()
    {
        if (--currentValue < 0)
            currentValue = maxSum;

        return currentValue;
    }
}