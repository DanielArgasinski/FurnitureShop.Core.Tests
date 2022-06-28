namespace FurnitureShop.Core.Tests.Processor
{
    internal class FurnitureReservationRequestProcessor
    {
        public FurnitureReservationRequestProcessor()
        {
        }

        internal FurnitureReservationResult FurnitureReservation(FurnitureReservationRequest request)
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
