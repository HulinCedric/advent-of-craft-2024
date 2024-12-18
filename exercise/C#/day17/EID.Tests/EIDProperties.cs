using FsCheck;
using FsCheck.Xunit;

namespace EID.Tests;

public class EIDProperties
{
    [Property(Arbitrary = [typeof(EIDGenerator)])]
    public Property RoundTripEID(EID eid)
        => (EID.Parse(eid.ToString()) == eid)
            .ToProperty();
}