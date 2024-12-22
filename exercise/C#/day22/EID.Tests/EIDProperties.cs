using FsCheck;

namespace EID.Tests
{
    public class EIDProperties
    {
        [FsCheck.Xunit.Property(Arbitrary = [typeof(EIDGenerator)])]
        public Property RoundTripEID(EID eid) =>
            EID.Parse(eid.ToString())
                .Exists(parsedEID => parsedEID == eid)
                .ToProperty();
    }
}