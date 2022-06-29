using FurnitureShop.Core.DataInterface;
using FurnitureShop.Core.Domain;

namespace FurnitureShop.Core.Processor
{
    public class FurnitureReservationRequestProcessor
    {
        private readonly IFurnitureReservationRepository _furnitureReservationRepository;

        public FurnitureReservationRequestProcessor()
        {
        }

        public FurnitureReservationRequestProcessor(IFurnitureReservationRepository furnitureReservationRepository)
        {
            _furnitureReservationRepository = furnitureReservationRepository;
        }

        public FurnitureReservationResult FurnitureReservation(FurnitureReservationRequest request)
        {
           
            _furnitureReservationRepository.Save(new FurnitureReservation
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                PhoneNu = request.PhoneNu,
                Date = request.Date,
            });


            return new FurnitureReservationResult
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                PhoneNu = request.PhoneNu,
                Date = request.Date,
            };
        }
    }
}
