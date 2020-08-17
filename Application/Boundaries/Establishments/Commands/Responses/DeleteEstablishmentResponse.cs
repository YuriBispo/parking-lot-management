namespace Application.Boundaries.Establishments.Commands.Responses
{
    public class DeleteEstablishmentResponse
    {
        public DeleteEstablishmentResponse(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}