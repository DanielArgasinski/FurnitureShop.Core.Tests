using FurnitureShop.Core.Domain;

namespace FurnitureShop.Core.Processor
{
    public class FurnitureReservationRequestProcessor
    {
        public FurnitureReservationRequestProcessor()
        {
        }

        public FurnitureReservationRequestProcessor(DataInterface.IFurnitureReservationRepository @object)
        {
        }

        public FurnitureReservationResult FurnitureReservation(FurnitureReservationRequest request)
        {
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
