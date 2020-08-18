using System.Collections.Generic;
using Domain.Entities.ParkingSpaces;
using Domain.Entities.ParkingSpaces.Enum;

namespace Application.Boundaries.ParkingSpaces.Queries.Responses
{
    public class OccupyParkingSpaceQueryResponse
    {
        public OccupyParkingSpaceQueryResponse()
        {
            
        }
        public OccupyParkingSpaceQueryResponse(IList<ParkingSpace> parkingSpaces)
        {
            foreach (var parkingSpace in parkingSpaces)
            {
                if(ParkingSpaces == null)
                    ParkingSpaces = new List<ParkingSpaceResponse>();

                ParkingSpaces.Add(new ParkingSpaceResponse(
                    parkingSpace.Id,
                    parkingSpace.Type
                ));
            }
        }

        public List<ParkingSpaceResponse> ParkingSpaces { get; set; }
    }

    public class ParkingSpaceResponse
    {
        public ParkingSpaceResponse(int id, ParkingSpaceType type)
        {
            Id = id;
            Type = type;
        }

        public int Id { get; set; }
        public ParkingSpaceType Type { get; set; }
    }
}