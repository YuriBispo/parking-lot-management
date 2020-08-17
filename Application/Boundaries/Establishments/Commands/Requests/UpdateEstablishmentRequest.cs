using Application.Boundaries.Establishments.Commands.Responses;
using MediatR;

namespace Application.Boundaries.Establishments.Commands.Requests
{
    public class UpdateEstablishmentRequest : IRequest<UpdateEstablishmentResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public UpdateAddressRequest Address { get; set; }
        public UpdatePhoneRequest Phone { get; set; }
        public int CarsCapacity { get; set; }
        public int MotorcyclesCapacity { get; set; }
    }

    public class UpdateAddressRequest
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class UpdatePhoneRequest 
    {
        public string CodeArea { get; set; }
        public string Number { get; set; }
    }
}