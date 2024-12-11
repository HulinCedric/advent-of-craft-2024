using Christmas.Tests.Generators;
using Christmas.Tests.Generators.Ages;
using Christmas.Tests.Generators.NumberOfGifts;
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
    
    [Property(Arbitrary = [typeof(BabyAges)])]
    public bool Returns_valid_category_for_babies(int age)
        => Preparation.CategorizeGift(age) == "Baby";
    
    [Property(Arbitrary = [typeof(ToddlerAges)])]
    public bool Returns_valid_category_for_toddlers(int age)
        => Preparation.CategorizeGift(age) == "Toddler";
    
    [Property(Arbitrary = [typeof(ChildAges)])]
    public bool Returns_valid_category_for_children(int age)
        => Preparation.CategorizeGift(age) == "Child";
    
    [Property(Arbitrary = [typeof(TeenAges)])]
    public bool Returns_valid_category_for_teens(int age)
        => Preparation.CategorizeGift(age) == "Teen";
}