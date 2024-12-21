﻿using System.Text;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Tour;

public class TourCalculatorNew(List<Step> steps)
{
    private readonly Seq<Step> _steps = steps.ToSeq();

    public Either<string, string> Calculate()
        => HasNotLocations()
            ? Left("No locations !!!")
            : Right($"{TourDetails()}{TourDeliveryTime()}{Environment.NewLine}");

    private bool HasNotLocations() => _steps.IsNull() || _steps.Count == 0;

    private string TourDetails()
        => _steps.OrderBy(x => x.Time)
            .Aggregate(string.Empty, (acc, s1) => acc + s1 + Environment.NewLine);

    private string TourDeliveryTime()
    {
        var tourDeliveryTime = _steps.Sum(s => s.DeliveryTime);

        DeliveryTime deliveryTime = new DeliveryTime(tourDeliveryTime);
        
        var str = deliveryTime.ToString();
        var toutDeliveryTimeRepresentation = $"Delivery time | {str}";
        return toutDeliveryTimeRepresentation;
    }
}

internal record DeliveryTime(int TimeInSeconds)
{
    public override string ToString()
    {
        var hhMmSs = @"hh\:mm\:ss";
        var fromSeconds = TimeSpan.FromSeconds(TimeInSeconds);
        return fromSeconds.ToString(hhMmSs);
    }
}