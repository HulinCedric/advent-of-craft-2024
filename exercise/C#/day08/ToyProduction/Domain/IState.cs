namespace ToyProduction.Domain;

internal interface IState
{
    void AssignToElf(Toy toy);
    void CompleteProduction(Toy toy);
}