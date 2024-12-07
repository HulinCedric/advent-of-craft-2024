namespace Workshop.Tests.Verifications;

public static class GiftAssertionExtensions
{
    public static GiftAssertions Should(this Gift? instance)
    {
        return new GiftAssertions(instance);
    }
}