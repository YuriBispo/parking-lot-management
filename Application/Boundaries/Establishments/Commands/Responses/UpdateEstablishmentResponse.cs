namespace Application.Boundaries.Establishments.Commands.Responses
{
    public class UpdateEstablishmentResponse
    {
        public UpdateEstablishmentResponse()
        {
        }

        public UpdateEstablishmentResponse(int id, string name, string cnpj, 
            string address, string phone, int carsCapacity, 
            int motorcyclesCapacity)
        {
            Id = id;
            Name = name;
            CNPJ = cnpj;
            Address = address;
            Phone = phone;
            CarsCapacity = carsCapacity;
            MotorcyclesCapacity = motorcyclesCapacity;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CarsCapacity { get; set; }
        public int MotorcyclesCapacity { get; set; }
    }
}