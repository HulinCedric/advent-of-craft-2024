using Christmas.Tests.Generators;
using FsCheck.Xunit;

namespace Christmas.Tests;

public class PreparationPropertyTests
{
    [Property(Arbitrary = [typeof(NoGifts)])]
    public bool Returns_valid_message_when_prepare_no_gifts(int numberOfGifts)
        => Preparation.PrepareGifts(numberOfGifts) == "No gifts to prepare.";
    
    [Property(Arbitrary = [typeof(ElvesGifts)])]
    public bool Returns_valid_message_when_elves_prepare_gifts(int numberOfGifts)
        => Preparation.PrepareGifts(numberOfGifts) == "Elves will prepare the gifts.";
    
    [Property(Arbitrary = [typeof(SantaGifts)])]
    public bool Returns_valid_message_when_santa_prepare_gifts(int numberOfGifts)
        => Preparation.PrepareGifts(numberOfGifts) == "Santa will prepare the gifts.";
}