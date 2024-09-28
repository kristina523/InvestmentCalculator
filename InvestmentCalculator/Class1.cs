using System;

public class InvestmentCalculator
{
    public static double CalculateCompoundInterest(double principal, double rate, double time, int compoundingsPerYear)
    {
        if (principal < 0)
            throw new ArgumentException("Основной капитал должен быть неотрицательным числом.");
        if (rate < 0)
            throw new ArgumentException("Процентная ставка должна быть неотрицательным числом.");
        if (time < 0)
            throw new ArgumentException("Время в годах должно быть неотрицательным числом.");
        if (compoundingsPerYear <= 0)
            throw new ArgumentException("Количество начислений процентов в год должно быть положительным целым числом.");

        return principal * Math.Pow(1 + rate / compoundingsPerYear, compoundingsPerYear * time);
    }
}