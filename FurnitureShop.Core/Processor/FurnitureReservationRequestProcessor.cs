using FurnitureShop.Core.DataInterface;
using FurnitureShop.Core.Domain;

namespace FurnitureShop.Core.Processor
{
    public class FurnitureReservationRequestProcessor
    {
        private readonly IFurnitureReservationRepository _furnitureReservationRepository;
        private readonly IReservationRepository _reservationRepository;

        public FurnitureReservationRequestProcessor(IFurnitureReservationRepository furnitureReservationRepository, IReservationRepository reservationRepository)
        {
            _furnitureReservationRepository = furnitureReservationRepository;
            _reservationRepository = reservationRepository;
        }

        public FurnitureReservationResult FurnitureReservation(FurnitureReservationRequest request)
        {
            var availableFurnitures = _reservationRepository.AvailaleFurniture(request.Date);
            if (availableFurnitures.Count() > 0)
            {
                _furnitureReservationRepository.Save(Create<FurnitureReservation>(request));
            }

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

