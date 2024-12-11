using Christmas.Tests.Generators;
using FsCheck.Xunit;

namespace Christmas.Tests;

public class PreparationPropertyTests
{
    [Property(Arbitrary = [typeof(NoGifts)])]
    public bool Returns_valid_message_when_prepare_no_gifts(int numberOfGifts)
        => Preparation.PrepareGifts(numberOfGifts) == "No gifts to prepare.";
}