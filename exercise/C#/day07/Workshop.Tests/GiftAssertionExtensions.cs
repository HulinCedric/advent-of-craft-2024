namespace Workshop.Tests;

public static class GiftAssertionExtensions
{
    public static GiftAssertions Should(this Gift? instance)
    {
        return new GiftAssertions(instance);
    }
}