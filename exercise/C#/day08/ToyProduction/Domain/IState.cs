namespace ToyProduction.Domain;

internal interface IState
{
    Toy AssignToElf(Toy toy);
    Toy CompleteProduction(Toy toy);
}