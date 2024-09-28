namespace TestProject1
{ 
using System;
using Xunit;

public class InvestmentCalculator
{
    public static double CalculateCompoundInterest(double principal, double rate, double time, int compoundingsPerYear)
    {
        if (principal < 0)
        {
            throw new ArgumentException("Основная сумма не может быть отрицательной.");
        }

        if (rate < 0)
        {
            throw new ArgumentException("Процентная ставка не может быть отрицательной.");
        }

        if (time < 0)
        {
            throw new ArgumentException("Время не может быть отрицательным.");
        }

        if (compoundingsPerYear <= 0)
        {
            throw new ArgumentException("Расчеты за год должны быть целым положительным числом.");
        }

        double amount = principal * Math.Pow(1 + (rate / compoundingsPerYear), compoundingsPerYear * time);
        return amount - principal;
    }
}

public class InvestmentCalculatorTests
{
    [Fact]
    public void CalculateCompoundInterest_ValidInputs_ReturnsExpectedResult()
    {
        double principal = 1000;
        double rate = 0.05;
        double time = 10;
        int compoundingsPerYear = 12;

        double result = InvestmentCalculator.CalculateCompoundInterest(principal, rate, time, compoundingsPerYear);

        Assert.Equal(1648.72, Math.Round(result, 2));
    }

    [Fact]
    public void CalculateCompoundInterest_NegativePrincipal_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => InvestmentCalculator.CalculateCompoundInterest(-1000, 0.05, 10, 12));
    }

    [Fact]
    public void CalculateCompoundInterest_NegativeRate_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => InvestmentCalculator.CalculateCompoundInterest(1000, -0.05, 10, 12));
    }

    [Fact]
    public void CalculateCompoundInterest_NegativeTime_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => InvestmentCalculator.CalculateCompoundInterest(1000, 0.05, -10, 12));
    }

    [Fact]
    public void CalculateCompoundInterest_NonPositiveCompoundings_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => InvestmentCalculator.CalculateCompoundInterest(1000, 0.05, 10, 0));
    }
}
}
