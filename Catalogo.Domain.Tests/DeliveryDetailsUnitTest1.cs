using Catalogo.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Catalogo.Domain.Tests
{
    public class DeliveryDetailsUnitTest1
    {
        [Fact(DisplayName = "Create Delivery Details With Valid State")]
        public void CreateDeliveryDetails_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new DeliveryDetails("Fabr�cio", "rua pascoal filippi", "47996933146", "400", "Vila Nova");
            action.Should()
                 .NotThrow<Catalogo.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Delivery Details With Invalid PhoneNumber")]
        public void CreateDeliveryDetails_WithInvalidPhoneNumber_ResultObjectValidState()
        {
            Action action = () => new DeliveryDetails("Fabr�cio", "rua pascoal filippi", "999999999999999999999999999999999", "400", "Vila Nova");
            action.Should()
                 .Throw<Catalogo.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Formato inv�lido para n�mero de telefone.");
        }

        [Fact(DisplayName = "Create Delivery Details With Adress Empty")]
        public void CreateDeliveryDetails_EmptyAdress_ResultObjectValidState()
        {
            Action action = () => new DeliveryDetails("Fabr�cio", "", "999999999999999999999999999999999", "400", "Vila Nova");
            action.Should()
                 .Throw<Catalogo.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Endere�o n�o pode ser vazio.");
        }
    }
}
