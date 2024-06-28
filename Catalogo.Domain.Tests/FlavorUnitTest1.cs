using Catalogo.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Catalogo.Domain.Tests
{
    public class FlavorUnitTest1
    {
        [Fact(DisplayName = "Create Flavor With Valid State")]
        public void CreateFlavor_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Flavor("Mussarela", 22.5m);
            action.Should()
                 .NotThrow<Catalogo.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Flavor With Invalid Price")]
        public void CreateFlavor_InvalidPrice_ResultObjectValidState()
        {
            Action action = () => new Flavor("Mussarela", 15.5m);
            action.Should()
                 .Throw<Catalogo.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Valor do sabor inválido");
        }

        [Fact(DisplayName = "Create Flavor With Name Is Null")]
        public void CreateFlavor_NameIsNull_ResultObjectValidState()
        {
            Action action = () => new Flavor("", 25.5m);
            action.Should()
                 .Throw<Catalogo.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Nome inválido. O nome é obrigatório");
        }
    }
}
