namespace Domain.Data
{
    public sealed class Establishment
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }
        public int CarsCapacity { get; private set; }
        public int MotorcyclesCapacity { get; private set; }

        public Establishment(int id,string name, string cnpj, Address address, string phone,
            int carsCapacity, int motorcyclesCapacity)
        {
            Id = id;
            Name = name;
            CNPJ = cnpj;
            Address = address;
            Phone = phone;
            CarsCapacity = carsCapacity;
            MotorcyclesCapacity = motorcyclesCapacity;
        }
    }
}