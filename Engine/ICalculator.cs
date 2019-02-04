using System;

namespace Engine
{
    public interface ICalculator
    {
        BaseRate Calculate(DateTime startDate, DateTime endDate);
    }
}
