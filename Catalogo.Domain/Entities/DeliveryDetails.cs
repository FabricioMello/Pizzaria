using Catalogo.Domain.Entities;
using Catalogo.Domain.Validation;

public sealed class DeliveryDetails : Entity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string HouseNumber { get; set; }
    public string District { get; set; }

    private DeliveryDetails() { }

    public DeliveryDetails(string customerName, string address, string phoneNumber, string houseNumber, string district)
    {
        Name = customerName;
        Address = address;
        PhoneNumber = phoneNumber;
        HouseNumber = houseNumber;
        District = district;

        ValidateDomain();
    }

    private void ValidateDomain()
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "Nome do cliente não pode ser vazio.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(Address), "Endereço não pode ser vazio.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(PhoneNumber), "Número de telefone não pode ser vazio.");
        DomainExceptionValidation.When(!IsValidPhoneNumber(PhoneNumber), "Formato inválido para número de telefone.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(HouseNumber), "Número da casa não pode ser vazio.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(District), "Bairro não pode ser vazio.");
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length >= 9 && phoneNumber.Length <= 15;
    }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}
