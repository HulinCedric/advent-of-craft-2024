namespace EID;

internal record EIDWithoutKey(Sex Sex, Year Year, SerialNumber SerialNumber)
{
    public override string ToString() => Representation();

    private string Representation() => $"{Sex}{Year}{SerialNumber}";

    internal int GetValue() => int.Parse(Representation());
}