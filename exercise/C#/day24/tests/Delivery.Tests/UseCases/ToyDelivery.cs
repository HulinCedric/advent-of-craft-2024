using Delivery.Domain;
using Delivery.Domain.Core;
using Delivery.Tests.Assertions;
using Delivery.Tests.Doubles;
using Delivery.UseCases;
using FluentAssertions;
using FluentAssertions.LanguageExt;
using LanguageExt;
using Xunit;
using static Delivery.Domain.Core.Error;
using Unit = LanguageExt.Unit;

namespace Delivery.Tests.UseCases
{
    public class ToyDelivery
    {
        private readonly InMemoryCatalog _catalog;
        private readonly ToyDeliveryUseCase _useCase;

        protected ToyDelivery()
        {
            _catalog = new InMemoryCatalog();
            _useCase = new ToyDeliveryUseCase(_catalog);
        }

        private Toy ForASuppliedToy(int stock = 1)
            => ToyBuilder.ToysInStock(stock)
                .Build()
                .Let(toy => _catalog.Save(toy));

        public class SuccessFully_When : ToyDelivery
        {
            [Fact]
            public void Toy_And_Update_Stock() =>
                ForASuppliedToy()
                    .Let(toy =>
                    {
                        var command = new GetToyByExternalIdQuery(toy.ExternalId!);

                        _useCase.Handle(command)
                            .Should()
                            .Be(Unit.Default);

                        toy.Version.Should().Be(2);
                        toy.Should()
                            .HaveRaisedEvent(_catalog,
                                new AnotherEvent(toy.Id, Time.Now)
                            );
                    });
        }

        public class Fail_When : ToyDelivery
        {
            [Fact]
            public void Toy_Has_Not_Been_Built()
            {
                const string notBuiltToy = "Not a Bike";

                _useCase.Handle(new GetToyByExternalIdQuery(notBuiltToy))
                    .Should()
                    .Be(AnError("Oops we have a problem... we have not build the toy: Not a Bike"));

                AssertThatNoEventHasBeenRaised();
            }

            [Fact]
            public void Toy_Is_Not_Supplied_Anymore()
                => ForASuppliedToy(0)
                    .Let(toy =>
                    {
                        _useCase.Handle(new GetToyByExternalIdQuery(toy.ExternalId!))
                            .Should()
                            .Be(AnError($"No more {toy.ExternalId} in stock"));

                        AssertThatNoEventHasBeenRaised();
                    });

            private void AssertThatNoEventHasBeenRaised()
                => _catalog.RaisedEvents()
                    .Should()
                    .BeEmpty();
        }
    }
}