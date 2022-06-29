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
                var _availableFurnitures = availableFurnitures.First();
                var FurnitureReservation = Create<FurnitureReservation>(request);
                FurnitureReservation.FurnitureId = _availableFurnitures.Id;

                _furnitureReservationRepository.Save(FurnitureReservation);
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

