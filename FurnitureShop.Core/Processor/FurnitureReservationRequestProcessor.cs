using FurnitureShop.Core.DataInterface;
using FurnitureShop.Core.Domain;

namespace FurnitureShop.Core.Processor
{
    public class FurnitureReservationRequestProcessor
    {
        private readonly IFurnitureReservationRepository _furnitureReservationRepository;

     
        public FurnitureReservationRequestProcessor(IFurnitureReservationRepository furnitureReservationRepository)
        {
            _furnitureReservationRepository = furnitureReservationRepository;
        }

        public FurnitureReservationResult FurnitureReservation(FurnitureReservationRequest request)
        {

            _furnitureReservationRepository.Save(Create<FurnitureReservation>(request));

            return Create<FurnitureReservationResult>(request);
        }

        private static T Create<T>(FurnitureReservationRequest request) where T : FurnitureReservationBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                PhoneNu = request.PhoneNu,
                Date = request.Date,
            };
        }
    }
}

