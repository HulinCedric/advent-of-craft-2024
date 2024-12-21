﻿using System.Text;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Tour;

public class TourCalculatorNew(List<Step> steps)
{
    private readonly Seq<Step> _steps = steps.ToSeq();

    public bool Calculated
    {
        get { return calculated; }
    }

    public double DeliveryTime
    {
        get { return _deliveryTime; }
    }

    private double _deliveryTime = 0;
    private bool calculated = false;

    public Either<string, string> Calculate()
    {
        if (_steps.IsNull() || _steps.Count == 0)
        {
            return Left("No locations !!!");
        }
        else
        {
            var result = new StringBuilder();

            foreach (var s in _steps.OrderBy(x => x.Time))
            {
                if (!calculated)
                {
                    this._deliveryTime += s.DeliveryTime;
                    result.AppendLine(fLine(s, _deliveryTime));
                }
            }

            string hhMmSs = @"hh\:mm\:ss";
            string str = TimeSpan.FromSeconds(this._deliveryTime).ToString(hhMmSs);
            result.AppendLine($"Delivery time | {str}");
            calculated = true;

            return Right(result.ToString());
        }
    }

    private string fLine(Step step, double x)
    {
        if (step == null)
            throw new InvalidOperationException();
        else
            return $"{step.Time} : {step.Label} | {step.DeliveryTime} sec";
    }
}